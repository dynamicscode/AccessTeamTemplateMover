using AccessTeamTemplateMoverPlugin.Command;
using AccessTeamTemplateMoverPlugin.Common;
using AccessTeamTemplateMoverPlugin.Interface;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace AccessTeamTemplateMoverPlugin
{
    public partial class MyPluginControl : MultipleConnectionsPluginControlBase, ILogWriter
    {
        private Settings mySettings;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
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
            if (string.IsNullOrEmpty(exportFilePathTextBox.Text) || string.IsNullOrEmpty(exportFileNameTextBox.Text))
            {
                MessageBox.Show("Please enter File Path and File Name to export.");
            }
            else
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Exporting access team templates",
                    Work = (worker, args) =>
                    {
                        execute(Operation.Export, Path.Combine(exportFilePathTextBox.Text, exportFileNameTextBox.Text));
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Successfully exported to {Path.Combine(exportFilePathTextBox.Text, exportFileNameTextBox.Text)} from {ConnectionDetail.ConnectionName}.");
                        }
                    }
                });
            }
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
            if (string.IsNullOrEmpty(importFileTextBox.Text))
            {
                MessageBox.Show("Please choose File to import.");
            }
            else
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Importing access team templates",
                    Work = (worker, args) =>
                    {
                        execute(Operation.Import, importFileTextBox.Text);
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Successfully imported from {importFileTextBox.Text} to {ConnectionDetail.ConnectionName}.");
                        }
                    }
                });
            }
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
            if (AdditionalConnectionDetails.Count < 1)
            {
                MessageBox.Show("Please connect to the target organisation.");
            }
            else
            {
                var fileName = Path.Combine(Application.UserAppDataPath, Path.GetRandomFileName());

                WorkAsync(new WorkAsyncInfo
                {
                    Message = $"Transferring access team templates",
                    Work = (worker, args) =>
                    {
                        LogInfo("test");
                        execute(Operation.Export, fileName);
                        execute(Operation.Import, fileName, AdditionalConnectionDetails.Last().GetCrmServiceClient());
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (File.Exists(fileName))
                                File.Delete(fileName);
                            MessageBox.Show($"Successfully transferred from {ConnectionDetail.ConnectionName} to {AdditionalConnectionDetails.Last().ConnectionName}.");
                        }
                    }
                });
            }
        }

        private void execute(Operation operation, string fileName, IOrganizationService service = null)
        {
            ICommand command = CommandFactory.GetInstance(operation);
            command.Service = service ?? Service;
            command.FileName = fileName;
            command.LogWriter = this;
            command.OrganisationUrl = service == null ? ConnectionDetail.WebApplicationUrl : AdditionalConnectionDetails.Last().WebApplicationUrl;
            command.Execute();
        }

        public void LogInfo(string message)
        {
            base.LogInfo(message);
        }

        public void LogError(string message)
        {
            base.LogError(message);
        }

        public void LogWarning(string message)
        {
            base.LogWarning(message);
        }

        public void Open()
        {
            base.OpenLogFile();
        }

        private void aboutToolButton_Click(object sender, EventArgs e)
        {
            new AccessTeamTemplateMoverAbout().ShowDialog(this);
        }
    }
}