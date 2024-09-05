using System.Drawing;
using System.Windows.Forms;

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
            lblUpdateFileVersions = new Label();
            lblBuildTM = new Label();
            progressBarTM = new ProgressBar();
            lblBuildWeb = new Label();
            progressBarWeb = new ProgressBar();
            lblCopyZips = new Label();
            progressBarCopyZip = new ProgressBar();
            lblBuildInstaller = new Label();
            progressBarInstaller = new ProgressBar();
            lblElapsedTimeFileVersion = new Label();
            lblElapsedTimeTM = new Label();
            lblElapsedTimeWeb = new Label();
            lblElapsedTimeCopyZips = new Label();
            lblElapsedTimeInstaller = new Label();
            chkOpenGitAfterBuild = new CheckBox();
            chkOpenOutputFolderAfterBuild = new CheckBox();
            lblStatusFileVersion = new Label();
            lblStatusTM = new Label();
            lblStatusWeb = new Label();
            lblStatusCopyZips = new Label();
            lblStatusInstaller = new Label();
            SuspendLayout();
            // 
            // lblSourcePath
            // 
            lblSourcePath.AutoSize = true;
            lblSourcePath.Location = new Point(12, 34);
            lblSourcePath.Name = "lblSourcePath";
            lblSourcePath.Size = new Size(167, 15);
            lblSourcePath.TabIndex = 0;
            lblSourcePath.Text = "Path to project /source/ folder";
            // 
            // txtSourcePath
            // 
            txtSourcePath.Location = new Point(185, 31);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(377, 23);
            txtSourcePath.TabIndex = 1;
            // 
            // btnBrowseSource
            // 
            btnBrowseSource.Location = new Point(568, 31);
            btnBrowseSource.Name = "btnBrowseSource";
            btnBrowseSource.Size = new Size(75, 23);
            btnBrowseSource.TabIndex = 2;
            btnBrowseSource.Text = "Browse...";
            btnBrowseSource.TextImageRelation = TextImageRelation.TextAboveImage;
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
            btnBuildAndPackage.Location = new Point(12, 301);
            btnBuildAndPackage.Name = "btnBuildAndPackage";
            btnBuildAndPackage.Size = new Size(173, 57);
            btnBuildAndPackage.TabIndex = 14;
            btnBuildAndPackage.Text = "Build And Zip";
            btnBuildAndPackage.UseVisualStyleBackColor = true;
            btnBuildAndPackage.Click += btnBuildAndPackage_Click;
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(185, 60);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(377, 23);
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
            progressBarUpdateFileVersions.Anchor = AnchorStyles.Left;
            progressBarUpdateFileVersions.Location = new Point(398, 223);
            progressBarUpdateFileVersions.Name = "progressBarUpdateFileVersions";
            progressBarUpdateFileVersions.Size = new Size(127, 23);
            progressBarUpdateFileVersions.TabIndex = 18;
            // 
            // lblUpdateFileVersions
            // 
            lblUpdateFileVersions.Anchor = AnchorStyles.Left;
            lblUpdateFileVersions.AutoSize = true;
            lblUpdateFileVersions.Location = new Point(280, 231);
            lblUpdateFileVersions.Name = "lblUpdateFileVersions";
            lblUpdateFileVersions.Size = new Size(112, 15);
            lblUpdateFileVersions.TabIndex = 19;
            lblUpdateFileVersions.Text = "Update File Versions";
            // 
            // lblBuildTM
            // 
            lblBuildTM.AutoSize = true;
            lblBuildTM.Location = new Point(296, 260);
            lblBuildTM.Name = "lblBuildTM";
            lblBuildTM.Size = new Size(95, 15);
            lblBuildTM.TabIndex = 21;
            lblBuildTM.Text = "Build and zip TM";
            // 
            // progressBarTM
            // 
            progressBarTM.Location = new Point(398, 252);
            progressBarTM.Name = "progressBarTM";
            progressBarTM.Size = new Size(127, 23);
            progressBarTM.TabIndex = 20;
            // 
            // lblBuildWeb
            // 
            lblBuildWeb.AutoSize = true;
            lblBuildWeb.Location = new Point(290, 289);
            lblBuildWeb.Name = "lblBuildWeb";
            lblBuildWeb.Size = new Size(102, 15);
            lblBuildWeb.TabIndex = 23;
            lblBuildWeb.Text = "Build and zip Web";
            // 
            // progressBarWeb
            // 
            progressBarWeb.Location = new Point(398, 281);
            progressBarWeb.Name = "progressBarWeb";
            progressBarWeb.Size = new Size(127, 23);
            progressBarWeb.TabIndex = 22;
            // 
            // lblCopyZips
            // 
            lblCopyZips.AutoSize = true;
            lblCopyZips.Location = new Point(237, 318);
            lblCopyZips.Name = "lblCopyZips";
            lblCopyZips.Size = new Size(155, 15);
            lblCopyZips.TabIndex = 25;
            lblCopyZips.Text = "Add TM and web to Installer";
            // 
            // progressBarCopyZip
            // 
            progressBarCopyZip.Location = new Point(398, 310);
            progressBarCopyZip.Name = "progressBarCopyZip";
            progressBarCopyZip.Size = new Size(127, 23);
            progressBarCopyZip.TabIndex = 24;
            // 
            // lblBuildInstaller
            // 
            lblBuildInstaller.AutoSize = true;
            lblBuildInstaller.Location = new Point(271, 347);
            lblBuildInstaller.Name = "lblBuildInstaller";
            lblBuildInstaller.Size = new Size(122, 15);
            lblBuildInstaller.TabIndex = 27;
            lblBuildInstaller.Text = "Build and zip Installer ";
            // 
            // progressBarInstaller
            // 
            progressBarInstaller.Location = new Point(398, 339);
            progressBarInstaller.Name = "progressBarInstaller";
            progressBarInstaller.Size = new Size(127, 23);
            progressBarInstaller.TabIndex = 26;
            // 
            // lblElapsedTimeFileVersion
            // 
            lblElapsedTimeFileVersion.Anchor = AnchorStyles.Left;
            lblElapsedTimeFileVersion.AutoSize = true;
            lblElapsedTimeFileVersion.Location = new Point(531, 231);
            lblElapsedTimeFileVersion.Name = "lblElapsedTimeFileVersion";
            lblElapsedTimeFileVersion.Size = new Size(48, 15);
            lblElapsedTimeFileVersion.TabIndex = 29;
            lblElapsedTimeFileVersion.Text = "Waiting";
            // 
            // lblElapsedTimeTM
            // 
            lblElapsedTimeTM.AutoSize = true;
            lblElapsedTimeTM.Location = new Point(531, 260);
            lblElapsedTimeTM.Name = "lblElapsedTimeTM";
            lblElapsedTimeTM.Size = new Size(48, 15);
            lblElapsedTimeTM.TabIndex = 30;
            lblElapsedTimeTM.Text = "Waiting";
            // 
            // lblElapsedTimeWeb
            // 
            lblElapsedTimeWeb.AutoSize = true;
            lblElapsedTimeWeb.Location = new Point(531, 289);
            lblElapsedTimeWeb.Name = "lblElapsedTimeWeb";
            lblElapsedTimeWeb.Size = new Size(48, 15);
            lblElapsedTimeWeb.TabIndex = 31;
            lblElapsedTimeWeb.Text = "Waiting";
            // 
            // lblElapsedTimeCopyZips
            // 
            lblElapsedTimeCopyZips.AutoSize = true;
            lblElapsedTimeCopyZips.Location = new Point(531, 318);
            lblElapsedTimeCopyZips.Name = "lblElapsedTimeCopyZips";
            lblElapsedTimeCopyZips.Size = new Size(48, 15);
            lblElapsedTimeCopyZips.TabIndex = 32;
            lblElapsedTimeCopyZips.Text = "Waiting";
            // 
            // lblElapsedTimeInstaller
            // 
            lblElapsedTimeInstaller.AutoSize = true;
            lblElapsedTimeInstaller.Location = new Point(531, 347);
            lblElapsedTimeInstaller.Name = "lblElapsedTimeInstaller";
            lblElapsedTimeInstaller.Size = new Size(48, 15);
            lblElapsedTimeInstaller.TabIndex = 33;
            lblElapsedTimeInstaller.Text = "Waiting";
            // 
            // chkOpenGitAfterBuild
            // 
            chkOpenGitAfterBuild.AutoSize = true;
            chkOpenGitAfterBuild.Checked = true;
            chkOpenGitAfterBuild.CheckState = CheckState.Checked;
            chkOpenGitAfterBuild.Location = new Point(12, 175);
            chkOpenGitAfterBuild.Name = "chkOpenGitAfterBuild";
            chkOpenGitAfterBuild.Size = new Size(171, 19);
            chkOpenGitAfterBuild.TabIndex = 34;
            chkOpenGitAfterBuild.Text = "Open TortoiseGit after build";
            chkOpenGitAfterBuild.UseVisualStyleBackColor = true;
            chkOpenGitAfterBuild.CheckedChanged += chkOpenGitAfterBuild_CheckedChanged;
            // 
            // chkOpenOutputFolderAfterBuild
            // 
            chkOpenOutputFolderAfterBuild.AutoSize = true;
            chkOpenOutputFolderAfterBuild.Location = new Point(12, 200);
            chkOpenOutputFolderAfterBuild.Name = "chkOpenOutputFolderAfterBuild";
            chkOpenOutputFolderAfterBuild.Size = new Size(201, 19);
            chkOpenOutputFolderAfterBuild.TabIndex = 35;
            chkOpenOutputFolderAfterBuild.Text = "Open output directory after build";
            chkOpenOutputFolderAfterBuild.UseVisualStyleBackColor = true;
            chkOpenOutputFolderAfterBuild.CheckedChanged += chkOpenOutputFolderAfterBuild_CheckedChanged;
            // 
            // lblStatusFileVersion
            // 
            lblStatusFileVersion.AutoSize = true;
            lblStatusFileVersion.Location = new Point(585, 233);
            lblStatusFileVersion.Name = "lblStatusFileVersion";
            lblStatusFileVersion.Size = new Size(0, 15);
            lblStatusFileVersion.TabIndex = 36;
            // 
            // lblStatusTM
            // 
            lblStatusTM.AutoSize = true;
            lblStatusTM.Location = new Point(585, 260);
            lblStatusTM.Name = "lblStatusTM";
            lblStatusTM.Size = new Size(0, 15);
            lblStatusTM.TabIndex = 37;
            // 
            // lblStatusWeb
            // 
            lblStatusWeb.AutoSize = true;
            lblStatusWeb.Location = new Point(585, 289);
            lblStatusWeb.Name = "lblStatusWeb";
            lblStatusWeb.Size = new Size(0, 15);
            lblStatusWeb.TabIndex = 38;
            // 
            // lblStatusCopyZips
            // 
            lblStatusCopyZips.AutoSize = true;
            lblStatusCopyZips.Location = new Point(586, 318);
            lblStatusCopyZips.Name = "lblStatusCopyZips";
            lblStatusCopyZips.Size = new Size(0, 15);
            lblStatusCopyZips.TabIndex = 39;
            // 
            // lblStatusInstaller
            // 
            lblStatusInstaller.AutoSize = true;
            lblStatusInstaller.Location = new Point(585, 347);
            lblStatusInstaller.Name = "lblStatusInstaller";
            lblStatusInstaller.Size = new Size(0, 15);
            lblStatusInstaller.TabIndex = 40;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 382);
            Controls.Add(lblStatusInstaller);
            Controls.Add(lblStatusCopyZips);
            Controls.Add(lblStatusWeb);
            Controls.Add(lblStatusTM);
            Controls.Add(lblStatusFileVersion);
            Controls.Add(chkOpenOutputFolderAfterBuild);
            Controls.Add(chkOpenGitAfterBuild);
            Controls.Add(lblElapsedTimeInstaller);
            Controls.Add(lblElapsedTimeCopyZips);
            Controls.Add(lblElapsedTimeWeb);
            Controls.Add(lblElapsedTimeTM);
            Controls.Add(lblElapsedTimeFileVersion);
            Controls.Add(lblBuildInstaller);
            Controls.Add(progressBarInstaller);
            Controls.Add(lblCopyZips);
            Controls.Add(progressBarCopyZip);
            Controls.Add(lblBuildWeb);
            Controls.Add(progressBarWeb);
            Controls.Add(lblBuildTM);
            Controls.Add(progressBarTM);
            Controls.Add(lblUpdateFileVersions);
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
        private Label lblUpdateFileVersions;
        private Label lblBuildTM;
        private ProgressBar progressBarTM;
        private Label lblBuildWeb;
        private ProgressBar progressBarWeb;
        private Label lblCopyZips;
        private ProgressBar progressBarCopyZip;
        private Label lblBuildInstaller;
        private ProgressBar progressBarInstaller;
        private Label lblElapsedTimeFileVersion;
        private Label lblElapsedTimeTM;
        private Label lblElapsedTimeWeb;
        private Label lblElapsedTimeCopyZips;
        private Label lblElapsedTimeInstaller;
        private CheckBox chkOpenGitAfterBuild;
        private CheckBox chkOpenOutputFolderAfterBuild;
        private Label lblStatusFileVersion;
        private Label lblStatusTM;
        private Label lblStatusWeb;
        private Label lblStatusCopyZips;
        private Label lblStatusInstaller;
    }
}
