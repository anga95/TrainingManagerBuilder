namespace TrainingManagerBuilder
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSourcePath = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            txtSourcePath = new TextBox();
            btnBrowseSource = new Button();
            txtCurrentMajor = new TextBox();
            txtCurrentMinor = new TextBox();
            txtCurrentBuild = new TextBox();
            txtCurrentRevision = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtNextRevision = new TextBox();
            txtNextBuild = new TextBox();
            txtNextMinor = new TextBox();
            txtNextMajor = new TextBox();
            btnUpdateVersion = new Button();
            btnBuildAndPackage = new Button();
            txtOutputPath = new TextBox();
            txtOutputDestination = new Label();
            btnBrowseOutput = new Button();
            SuspendLayout();
            // 
            // lblSourcePath
            // 
            lblSourcePath.AutoSize = true;
            lblSourcePath.Location = new Point(12, 34);
            lblSourcePath.Name = "lblSourcePath";
            lblSourcePath.Size = new Size(228, 15);
            lblSourcePath.TabIndex = 0;
            lblSourcePath.Text = "Path to /source/ that contains the .sln file:";
            // 
            // txtSourcePath
            // 
            txtSourcePath.Location = new Point(246, 31);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(316, 23);
            txtSourcePath.TabIndex = 1;
            // 
            // btnBrowseSource
            // 
            btnBrowseSource.Location = new Point(568, 31);
            btnBrowseSource.Name = "btnBrowseSource";
            btnBrowseSource.Size = new Size(75, 23);
            btnBrowseSource.TabIndex = 2;
            btnBrowseSource.Text = "Browse...";
            btnBrowseSource.UseVisualStyleBackColor = true;
            btnBrowseSource.Click += btnBrowseSource_Click;
            // 
            // txtCurrentMajor
            // 
            txtCurrentMajor.Location = new Point(107, 79);
            txtCurrentMajor.Name = "txtCurrentMajor";
            txtCurrentMajor.Size = new Size(45, 23);
            txtCurrentMajor.TabIndex = 3;
            // 
            // txtCurrentMinor
            // 
            txtCurrentMinor.Location = new Point(158, 79);
            txtCurrentMinor.Name = "txtCurrentMinor";
            txtCurrentMinor.Size = new Size(45, 23);
            txtCurrentMinor.TabIndex = 4;
            // 
            // txtCurrentBuild
            // 
            txtCurrentBuild.Location = new Point(209, 79);
            txtCurrentBuild.Name = "txtCurrentBuild";
            txtCurrentBuild.Size = new Size(45, 23);
            txtCurrentBuild.TabIndex = 5;
            // 
            // txtCurrentRevision
            // 
            txtCurrentRevision.Location = new Point(260, 79);
            txtCurrentRevision.Name = "txtCurrentRevision";
            txtCurrentRevision.Size = new Size(45, 23);
            txtCurrentRevision.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 82);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 7;
            label1.Text = "Current version";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 120);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 12;
            label2.Text = "Next version";
            // 
            // txtNextRevision
            // 
            txtNextRevision.Location = new Point(260, 117);
            txtNextRevision.Name = "txtNextRevision";
            txtNextRevision.Size = new Size(45, 23);
            txtNextRevision.TabIndex = 11;
            // 
            // txtNextBuild
            // 
            txtNextBuild.Location = new Point(209, 117);
            txtNextBuild.Name = "txtNextBuild";
            txtNextBuild.Size = new Size(45, 23);
            txtNextBuild.TabIndex = 10;
            // 
            // txtNextMinor
            // 
            txtNextMinor.Location = new Point(158, 117);
            txtNextMinor.Name = "txtNextMinor";
            txtNextMinor.Size = new Size(45, 23);
            txtNextMinor.TabIndex = 9;
            // 
            // txtNextMajor
            // 
            txtNextMajor.Location = new Point(107, 117);
            txtNextMajor.Name = "txtNextMajor";
            txtNextMajor.Size = new Size(45, 23);
            txtNextMajor.TabIndex = 8;
            // 
            // btnUpdateVersion
            // 
            btnUpdateVersion.Location = new Point(107, 146);
            btnUpdateVersion.Name = "btnUpdateVersion";
            btnUpdateVersion.Size = new Size(198, 33);
            btnUpdateVersion.TabIndex = 13;
            btnUpdateVersion.Text = "Update to next version";
            btnUpdateVersion.UseVisualStyleBackColor = true;
            btnUpdateVersion.Click += btnUpdateVersion_Click;
            // 
            // btnBuildAndPackage
            // 
            btnBuildAndPackage.Location = new Point(209, 314);
            btnBuildAndPackage.Name = "btnBuildAndPackage";
            btnBuildAndPackage.Size = new Size(173, 57);
            btnBuildAndPackage.TabIndex = 14;
            btnBuildAndPackage.Text = "Build And Zip";
            btnBuildAndPackage.UseVisualStyleBackColor = true;
            btnBuildAndPackage.Click += btnBuildAndPackage_Click;
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(168, 238);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(394, 23);
            txtOutputPath.TabIndex = 15;
            // 
            // txtOutputDestination
            // 
            txtOutputDestination.AutoSize = true;
            txtOutputDestination.Location = new Point(20, 241);
            txtOutputDestination.Name = "txtOutputDestination";
            txtOutputDestination.Size = new Size(142, 15);
            txtOutputDestination.TabIndex = 16;
            txtOutputDestination.Text = "Destination path for build";
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Location = new Point(568, 238);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(75, 23);
            btnBrowseOutput.TabIndex = 17;
            btnBrowseOutput.Text = "Browse...";
            btnBrowseOutput.UseVisualStyleBackColor = true;
            btnBrowseOutput.Click += btnBrowseOutput_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 382);
            Controls.Add(btnBrowseOutput);
            Controls.Add(txtOutputDestination);
            Controls.Add(txtOutputPath);
            Controls.Add(btnBuildAndPackage);
            Controls.Add(btnUpdateVersion);
            Controls.Add(label2);
            Controls.Add(txtNextRevision);
            Controls.Add(txtNextBuild);
            Controls.Add(txtNextMinor);
            Controls.Add(txtNextMajor);
            Controls.Add(label1);
            Controls.Add(txtCurrentRevision);
            Controls.Add(txtCurrentBuild);
            Controls.Add(txtCurrentMinor);
            Controls.Add(txtCurrentMajor);
            Controls.Add(btnBrowseSource);
            Controls.Add(txtSourcePath);
            Controls.Add(lblSourcePath);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSourcePath;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox txtSourcePath;
        private Button btnBrowseSource;
        private TextBox txtCurrentMajor;
        private TextBox txtCurrentMinor;
        private TextBox txtCurrentBuild;
        private TextBox txtCurrentRevision;
        private Label label1;
        private Label label2;
        private TextBox txtNextRevision;
        private TextBox txtNextBuild;
        private TextBox txtNextMinor;
        private TextBox txtNextMajor;
        private Button btnUpdateVersion;
        private Button btnBuildAndPackage;
        private TextBox txtOutputPath;
        private Label txtOutputDestination;
        private Button btnBrowseOutput;
    }
}
