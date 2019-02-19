using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using AccessTeamMoverPlugin.Command;
using System.IO;
using System.Collections.Specialized;
using AccessTeamMoverPlugin.Common;

namespace AccessTeamMoverPlugin
{
    public partial class MyPluginControl : MultipleConnectionsPluginControlBase
    {
        private Settings mySettings;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetAccounts);
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void exportFilePathButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                exportFilePathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void exportAndSaveButton_Click(object sender, EventArgs e)
        {
            Execute(Operation.Export, Path.Combine(exportFilePathTextBox.Text, exportFileNameTextBox.Text));
        }

        private void chooseImportFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            Execute(Operation.Import, importFileTextBox.Text);
        }

        private void targetEnvironmentButton_Click(object sender, EventArgs e)
        {
            AddAdditionalOrganization();
        }

        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e)
        {
            if (AdditionalConnectionDetails != null && AdditionalConnectionDetails.Count > 0)
            {
                targetEnvironmentTextBox.Text = AdditionalConnectionDetails.Last().ConnectionName;
            }
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Transferring access team templates",
                Work = (worker, args) =>
                {
                    ICommand command = CommandFactory.GetInstance(Common.Operation.Export);
                    command.Service = Service;
                    command.FileName = "accessteamtemplates_temp.xml";
                    command.Execute();

                    command = CommandFactory.GetInstance(Common.Operation.Import);
                    command.Service = AdditionalConnectionDetails.Last().GetCrmServiceClient();
                    command.FileName = "accessteamtemplates_temp.xml";
                    command.Execute();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Successfully transferred to {AdditionalConnectionDetails.Last().ConnectionName}");
                    }
                }
            });
        }

        private void Execute(Operation operation, string fileName, IOrganizationService service = null)
        {
            ICommand command = CommandFactory.GetInstance(Common.Operation.Export);
            command.Service = service ?? Service;
            command.FileName = fileName;

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"{(operation == Operation.Export ? "Exporting" : "Importing")} access team templates",
                Work = (worker, args) =>
                {
                    command.Execute();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Successfully {(operation == Operation.Export ? "exported to " : "imported from ")} {command.FileName}");
                    }
                }
            });
        }
    }
}