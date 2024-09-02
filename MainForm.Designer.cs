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
            btnBuildAndPackage = new Button();
            txtOutputPath = new TextBox();
            txtOutputDestination = new Label();
            btnBrowseOutput = new Button();
            progressBarUpdateFileVersions = new ProgressBar();
            lblProgressVersions = new Label();
            lblProgressTM = new Label();
            progressBarTM = new ProgressBar();
            lblProgressWeb = new Label();
            progressBarWeb = new ProgressBar();
            lblProgressMoveZips = new Label();
            progressBarMove = new ProgressBar();
            lblProgressInstaller = new Label();
            progressBarInstaller = new ProgressBar();
            lblElapsedTime = new Label();
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
            txtCurrentMajor.Location = new Point(107, 105);
            txtCurrentMajor.Name = "txtCurrentMajor";
            txtCurrentMajor.Size = new Size(45, 23);
            txtCurrentMajor.TabIndex = 3;
            // 
            // txtCurrentMinor
            // 
            txtCurrentMinor.Location = new Point(158, 105);
            txtCurrentMinor.Name = "txtCurrentMinor";
            txtCurrentMinor.Size = new Size(45, 23);
            txtCurrentMinor.TabIndex = 4;
            // 
            // txtCurrentBuild
            // 
            txtCurrentBuild.Location = new Point(209, 105);
            txtCurrentBuild.Name = "txtCurrentBuild";
            txtCurrentBuild.Size = new Size(45, 23);
            txtCurrentBuild.TabIndex = 5;
            // 
            // txtCurrentRevision
            // 
            txtCurrentRevision.Location = new Point(260, 105);
            txtCurrentRevision.Name = "txtCurrentRevision";
            txtCurrentRevision.Size = new Size(45, 23);
            txtCurrentRevision.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 108);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 7;
            label1.Text = "Current version";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 146);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 12;
            label2.Text = "Next version";
            // 
            // txtNextRevision
            // 
            txtNextRevision.Location = new Point(260, 143);
            txtNextRevision.Name = "txtNextRevision";
            txtNextRevision.Size = new Size(45, 23);
            txtNextRevision.TabIndex = 11;
            // 
            // txtNextBuild
            // 
            txtNextBuild.Location = new Point(209, 143);
            txtNextBuild.Name = "txtNextBuild";
            txtNextBuild.Size = new Size(45, 23);
            txtNextBuild.TabIndex = 10;
            // 
            // txtNextMinor
            // 
            txtNextMinor.Location = new Point(158, 143);
            txtNextMinor.Name = "txtNextMinor";
            txtNextMinor.Size = new Size(45, 23);
            txtNextMinor.TabIndex = 9;
            // 
            // txtNextMajor
            // 
            txtNextMajor.Location = new Point(107, 143);
            txtNextMajor.Name = "txtNextMajor";
            txtNextMajor.Size = new Size(45, 23);
            txtNextMajor.TabIndex = 8;
            // 
            // btnBuildAndPackage
            // 
            btnBuildAndPackage.Location = new Point(30, 221);
            btnBuildAndPackage.Name = "btnBuildAndPackage";
            btnBuildAndPackage.Size = new Size(173, 57);
            btnBuildAndPackage.TabIndex = 14;
            btnBuildAndPackage.Text = "Build And Zip";
            btnBuildAndPackage.UseVisualStyleBackColor = true;
            btnBuildAndPackage.Click += btnBuildAndPackage_Click;
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(168, 60);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(394, 23);
            txtOutputPath.TabIndex = 15;
            // 
            // txtOutputDestination
            // 
            txtOutputDestination.AutoSize = true;
            txtOutputDestination.Location = new Point(12, 63);
            txtOutputDestination.Name = "txtOutputDestination";
            txtOutputDestination.Size = new Size(142, 15);
            txtOutputDestination.TabIndex = 16;
            txtOutputDestination.Text = "Destination path for build";
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Location = new Point(568, 60);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(75, 23);
            btnBrowseOutput.TabIndex = 17;
            btnBrowseOutput.Text = "Browse...";
            btnBrowseOutput.UseVisualStyleBackColor = true;
            btnBrowseOutput.Click += btnBrowseOutput_Click;
            // 
            // progressBarUpdateFileVersions
            // 
            progressBarUpdateFileVersions.Location = new Point(405, 171);
            progressBarUpdateFileVersions.Name = "progressBarUpdateFileVersions";
            progressBarUpdateFileVersions.Size = new Size(127, 23);
            progressBarUpdateFileVersions.TabIndex = 18;
            // 
            // lblProgressVersions
            // 
            lblProgressVersions.AutoSize = true;
            lblProgressVersions.Location = new Point(287, 179);
            lblProgressVersions.Name = "lblProgressVersions";
            lblProgressVersions.Size = new Size(112, 15);
            lblProgressVersions.TabIndex = 19;
            lblProgressVersions.Text = "Update File Versions";
            // 
            // lblProgressTM
            // 
            lblProgressTM.AutoSize = true;
            lblProgressTM.Location = new Point(303, 225);
            lblProgressTM.Name = "lblProgressTM";
            lblProgressTM.Size = new Size(96, 15);
            lblProgressTM.TabIndex = 21;
            lblProgressTM.Text = "Build and Zip Tm";
            // 
            // progressBarTM
            // 
            progressBarTM.Location = new Point(405, 217);
            progressBarTM.Name = "progressBarTM";
            progressBarTM.Size = new Size(127, 23);
            progressBarTM.TabIndex = 20;
            // 
            // lblProgressWeb
            // 
            lblProgressWeb.AutoSize = true;
            lblProgressWeb.Location = new Point(297, 254);
            lblProgressWeb.Name = "lblProgressWeb";
            lblProgressWeb.Size = new Size(102, 15);
            lblProgressWeb.TabIndex = 23;
            lblProgressWeb.Text = "Build and zip Web";
            // 
            // progressBarWeb
            // 
            progressBarWeb.Location = new Point(405, 246);
            progressBarWeb.Name = "progressBarWeb";
            progressBarWeb.Size = new Size(127, 23);
            progressBarWeb.TabIndex = 22;
            // 
            // lblProgressMoveZips
            // 
            lblProgressMoveZips.AutoSize = true;
            lblProgressMoveZips.Location = new Point(244, 301);
            lblProgressMoveZips.Name = "lblProgressMoveZips";
            lblProgressMoveZips.Size = new Size(155, 15);
            lblProgressMoveZips.TabIndex = 25;
            lblProgressMoveZips.Text = "Add TM and web to Installer";
            // 
            // progressBarMove
            // 
            progressBarMove.Location = new Point(405, 293);
            progressBarMove.Name = "progressBarMove";
            progressBarMove.Size = new Size(127, 23);
            progressBarMove.TabIndex = 24;
            // 
            // lblProgressInstaller
            // 
            lblProgressInstaller.AutoSize = true;
            lblProgressInstaller.Location = new Point(278, 343);
            lblProgressInstaller.Name = "lblProgressInstaller";
            lblProgressInstaller.Size = new Size(121, 15);
            lblProgressInstaller.TabIndex = 27;
            lblProgressInstaller.Text = "Build Installer and Zip";
            // 
            // progressBarInstaller
            // 
            progressBarInstaller.Location = new Point(405, 335);
            progressBarInstaller.Name = "progressBarInstaller";
            progressBarInstaller.Size = new Size(127, 23);
            progressBarInstaller.TabIndex = 26;
            // 
            // lblElapsedTime
            // 
            lblElapsedTime.AutoSize = true;
            lblElapsedTime.Location = new Point(43, 311);
            lblElapsedTime.Name = "lblElapsedTime";
            lblElapsedTime.Size = new Size(86, 15);
            lblElapsedTime.TabIndex = 28;
            lblElapsedTime.Text = "lblElapsedTime";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 382);
            Controls.Add(lblElapsedTime);
            Controls.Add(lblProgressInstaller);
            Controls.Add(progressBarInstaller);
            Controls.Add(lblProgressMoveZips);
            Controls.Add(progressBarMove);
            Controls.Add(lblProgressWeb);
            Controls.Add(progressBarWeb);
            Controls.Add(lblProgressTM);
            Controls.Add(progressBarTM);
            Controls.Add(lblProgressVersions);
            Controls.Add(progressBarUpdateFileVersions);
            Controls.Add(btnBrowseOutput);
            Controls.Add(txtOutputDestination);
            Controls.Add(txtOutputPath);
            Controls.Add(btnBuildAndPackage);
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
        private Button btnBuildAndPackage;
        private TextBox txtOutputPath;
        private Label txtOutputDestination;
        private Button btnBrowseOutput;
        private ProgressBar progressBarUpdateFileVersions;
        private Label lblProgressVersions;
        private Label lblProgressTM;
        private ProgressBar progressBarTM;
        private Label lblProgressWeb;
        private ProgressBar progressBarWeb;
        private Label lblProgressMoveZips;
        private ProgressBar progressBarMove;
        private Label lblProgressInstaller;
        private ProgressBar progressBarInstaller;
        private Label lblElapsedTime;
    }
}
