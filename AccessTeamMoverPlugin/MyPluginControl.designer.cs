namespace AccessTeamTemplateMoverPlugin
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolButton = new System.Windows.Forms.ToolStripLabel();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.exportGroupBox = new System.Windows.Forms.GroupBox();
            this.exportFileNameLabel = new System.Windows.Forms.Label();
            this.exportFileNameTextBox = new System.Windows.Forms.TextBox();
            this.exportFilePathLabel = new System.Windows.Forms.Label();
            this.exportAndSaveButton = new System.Windows.Forms.Button();
            this.exportFilePathButton = new System.Windows.Forms.Button();
            this.exportFilePathTextBox = new System.Windows.Forms.TextBox();
            this.importGroupBox = new System.Windows.Forms.GroupBox();
            this.importFileLabel = new System.Windows.Forms.Label();
            this.importButton = new System.Windows.Forms.Button();
            this.chooseImportFileButton = new System.Windows.Forms.Button();
            this.importFileTextBox = new System.Windows.Forms.TextBox();
            this.transferGroupBox = new System.Windows.Forms.GroupBox();
            this.targetEnvironmentLabel = new System.Windows.Forms.Label();
            this.transferButton = new System.Windows.Forms.Button();
            this.targetEnvironmentButton = new System.Windows.Forms.Button();
            this.targetEnvironmentTextBox = new System.Windows.Forms.TextBox();
            this.toolStripMenu.SuspendLayout();
            this.exportGroupBox.SuspendLayout();
            this.importGroupBox.SuspendLayout();
            this.transferGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.aboutToolButton});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(806, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(86, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // aboutToolButton
            // 
            this.aboutToolButton.Name = "aboutToolButton";
            this.aboutToolButton.Size = new System.Drawing.Size(40, 22);
            this.aboutToolButton.Text = "About";
            this.aboutToolButton.Click += new System.EventHandler(this.aboutToolButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // exportGroupBox
            // 
            this.exportGroupBox.AutoSize = true;
            this.exportGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.exportGroupBox.Controls.Add(this.exportFileNameLabel);
            this.exportGroupBox.Controls.Add(this.exportFileNameTextBox);
            this.exportGroupBox.Controls.Add(this.exportFilePathLabel);
            this.exportGroupBox.Controls.Add(this.exportAndSaveButton);
            this.exportGroupBox.Controls.Add(this.exportFilePathButton);
            this.exportGroupBox.Controls.Add(this.exportFilePathTextBox);
            this.exportGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.exportGroupBox.Location = new System.Drawing.Point(0, 25);
            this.exportGroupBox.Name = "exportGroupBox";
            this.exportGroupBox.Size = new System.Drawing.Size(806, 119);
            this.exportGroupBox.TabIndex = 7;
            this.exportGroupBox.TabStop = false;
            this.exportGroupBox.Text = "Export";
            // 
            // exportFileNameLabel
            // 
            this.exportFileNameLabel.AutoSize = true;
            this.exportFileNameLabel.Location = new System.Drawing.Point(7, 46);
            this.exportFileNameLabel.Name = "exportFileNameLabel";
            this.exportFileNameLabel.Size = new System.Drawing.Size(52, 13);
            this.exportFileNameLabel.TabIndex = 6;
            this.exportFileNameLabel.Text = "File name";
            // 
            // exportFileNameTextBox
            // 
            this.exportFileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportFileNameTextBox.Location = new System.Drawing.Point(60, 46);
            this.exportFileNameTextBox.Name = "exportFileNameTextBox";
            this.exportFileNameTextBox.Size = new System.Drawing.Size(631, 20);
            this.exportFileNameTextBox.TabIndex = 5;
            this.exportFileNameTextBox.Text = "accessteams.xml";
            // 
            // exportFilePathLabel
            // 
            this.exportFilePathLabel.AutoSize = true;
            this.exportFilePathLabel.Location = new System.Drawing.Point(7, 20);
            this.exportFilePathLabel.Name = "exportFilePathLabel";
            this.exportFilePathLabel.Size = new System.Drawing.Size(47, 13);
            this.exportFilePathLabel.TabIndex = 4;
            this.exportFilePathLabel.Text = "File path";
            // 
            // exportAndSaveButton
            // 
            this.exportAndSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportAndSaveButton.Location = new System.Drawing.Point(696, 46);
            this.exportAndSaveButton.Name = "exportAndSaveButton";
            this.exportAndSaveButton.Size = new System.Drawing.Size(104, 54);
            this.exportAndSaveButton.TabIndex = 3;
            this.exportAndSaveButton.Text = "Export and Save";
            this.exportAndSaveButton.UseVisualStyleBackColor = true;
            // 
            // exportFilePathButton
            // 
            this.exportFilePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportFilePathButton.Location = new System.Drawing.Point(696, 18);
            this.exportFilePathButton.Name = "exportFilePathButton";
            this.exportFilePathButton.Size = new System.Drawing.Size(104, 23);
            this.exportFilePathButton.TabIndex = 2;
            this.exportFilePathButton.Text = "Choose file path";
            this.exportFilePathButton.UseVisualStyleBackColor = true;
            // 
            // exportFilePathTextBox
            // 
            this.exportFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportFilePathTextBox.Location = new System.Drawing.Point(60, 20);
            this.exportFilePathTextBox.Name = "exportFilePathTextBox";
            this.exportFilePathTextBox.Size = new System.Drawing.Size(631, 20);
            this.exportFilePathTextBox.TabIndex = 1;
            // 
            // importGroupBox
            // 
            this.importGroupBox.AutoSize = true;
            this.importGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.importGroupBox.Controls.Add(this.importFileLabel);
            this.importGroupBox.Controls.Add(this.importButton);
            this.importGroupBox.Controls.Add(this.chooseImportFileButton);
            this.importGroupBox.Controls.Add(this.importFileTextBox);
            this.importGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.importGroupBox.Location = new System.Drawing.Point(0, 144);
            this.importGroupBox.Name = "importGroupBox";
            this.importGroupBox.Size = new System.Drawing.Size(806, 119);
            this.importGroupBox.TabIndex = 8;
            this.importGroupBox.TabStop = false;
            this.importGroupBox.Text = "Import";
            // 
            // importFileLabel
            // 
            this.importFileLabel.AutoSize = true;
            this.importFileLabel.Location = new System.Drawing.Point(7, 20);
            this.importFileLabel.Name = "importFileLabel";
            this.importFileLabel.Size = new System.Drawing.Size(47, 13);
            this.importFileLabel.TabIndex = 4;
            this.importFileLabel.Text = "File path";
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(696, 46);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(104, 54);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // chooseImportFileButton
            // 
            this.chooseImportFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseImportFileButton.Location = new System.Drawing.Point(696, 18);
            this.chooseImportFileButton.Name = "chooseImportFileButton";
            this.chooseImportFileButton.Size = new System.Drawing.Size(104, 23);
            this.chooseImportFileButton.TabIndex = 2;
            this.chooseImportFileButton.Text = "Choose file";
            this.chooseImportFileButton.UseVisualStyleBackColor = true;
            // 
            // importFileTextBox
            // 
            this.importFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importFileTextBox.Location = new System.Drawing.Point(60, 20);
            this.importFileTextBox.Name = "importFileTextBox";
            this.importFileTextBox.Size = new System.Drawing.Size(631, 20);
            this.importFileTextBox.TabIndex = 1;
            // 
            // transferGroupBox
            // 
            this.transferGroupBox.AutoSize = true;
            this.transferGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.transferGroupBox.Controls.Add(this.targetEnvironmentLabel);
            this.transferGroupBox.Controls.Add(this.transferButton);
            this.transferGroupBox.Controls.Add(this.targetEnvironmentButton);
            this.transferGroupBox.Controls.Add(this.targetEnvironmentTextBox);
            this.transferGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.transferGroupBox.Location = new System.Drawing.Point(0, 263);
            this.transferGroupBox.Name = "transferGroupBox";
            this.transferGroupBox.Size = new System.Drawing.Size(806, 119);
            this.transferGroupBox.TabIndex = 9;
            this.transferGroupBox.TabStop = false;
            this.transferGroupBox.Text = "Transfer";
            // 
            // targetEnvironmentLabel
            // 
            this.targetEnvironmentLabel.AutoSize = true;
            this.targetEnvironmentLabel.Location = new System.Drawing.Point(7, 20);
            this.targetEnvironmentLabel.Name = "targetEnvironmentLabel";
            this.targetEnvironmentLabel.Size = new System.Drawing.Size(38, 13);
            this.targetEnvironmentLabel.TabIndex = 4;
            this.targetEnvironmentLabel.Text = "Target";
            // 
            // transferButton
            // 
            this.transferButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.transferButton.Location = new System.Drawing.Point(696, 46);
            this.transferButton.Name = "transferButton";
            this.transferButton.Size = new System.Drawing.Size(104, 54);
            this.transferButton.TabIndex = 3;
            this.transferButton.Text = "Transfer";
            this.transferButton.UseVisualStyleBackColor = true;
            // 
            // targetEnvironmentButton
            // 
            this.targetEnvironmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.targetEnvironmentButton.Location = new System.Drawing.Point(696, 18);
            this.targetEnvironmentButton.Name = "targetEnvironmentButton";
            this.targetEnvironmentButton.Size = new System.Drawing.Size(104, 23);
            this.targetEnvironmentButton.TabIndex = 2;
            this.targetEnvironmentButton.Text = "Choose target";
            this.targetEnvironmentButton.UseVisualStyleBackColor = true;
            // 
            // targetEnvironmentTextBox
            // 
            this.targetEnvironmentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetEnvironmentTextBox.Location = new System.Drawing.Point(60, 20);
            this.targetEnvironmentTextBox.Name = "targetEnvironmentTextBox";
            this.targetEnvironmentTextBox.ReadOnly = true;
            this.targetEnvironmentTextBox.Size = new System.Drawing.Size(631, 20);
            this.targetEnvironmentTextBox.TabIndex = 1;
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.transferGroupBox);
            this.Controls.Add(this.importGroupBox);
            this.Controls.Add(this.exportGroupBox);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(806, 655);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.exportGroupBox.ResumeLayout(false);
            this.exportGroupBox.PerformLayout();
            this.importGroupBox.ResumeLayout(false);
            this.importGroupBox.PerformLayout();
            this.transferGroupBox.ResumeLayout(false);
            this.transferGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripLabel aboutToolButton;
        private System.Windows.Forms.GroupBox exportGroupBox;
        private System.Windows.Forms.Label exportFileNameLabel;
        private System.Windows.Forms.TextBox exportFileNameTextBox;
        private System.Windows.Forms.Label exportFilePathLabel;
        private System.Windows.Forms.Button exportAndSaveButton;
        private System.Windows.Forms.Button exportFilePathButton;
        private System.Windows.Forms.TextBox exportFilePathTextBox;
        private System.Windows.Forms.GroupBox importGroupBox;
        private System.Windows.Forms.Label importFileLabel;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button chooseImportFileButton;
        private System.Windows.Forms.TextBox importFileTextBox;
        private System.Windows.Forms.GroupBox transferGroupBox;
        private System.Windows.Forms.Label targetEnvironmentLabel;
        private System.Windows.Forms.Button transferButton;
        private System.Windows.Forms.Button targetEnvironmentButton;
        private System.Windows.Forms.TextBox targetEnvironmentTextBox;
    }
}
