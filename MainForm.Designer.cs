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
            this.lblSourcePath = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtCurrentMajor = new System.Windows.Forms.TextBox();
            this.txtCurrentMinor = new System.Windows.Forms.TextBox();
            this.txtCurrentBuild = new System.Windows.Forms.TextBox();
            this.txtCurrentRevision = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNextRevision = new System.Windows.Forms.TextBox();
            this.txtNextBuild = new System.Windows.Forms.TextBox();
            this.txtNextMinor = new System.Windows.Forms.TextBox();
            this.txtNextMajor = new System.Windows.Forms.TextBox();
            this.btnBuildAndPackage = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.txtOutputDestination = new System.Windows.Forms.Label();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.progressBarUpdateFileVersions = new System.Windows.Forms.ProgressBar();
            this.lblUpdateFileVersions = new System.Windows.Forms.Label();
            this.lblBuildTM = new System.Windows.Forms.Label();
            this.progressBarTM = new System.Windows.Forms.ProgressBar();
            this.lblBuildWeb = new System.Windows.Forms.Label();
            this.progressBarWeb = new System.Windows.Forms.ProgressBar();
            this.lblCopyZips = new System.Windows.Forms.Label();
            this.progressBarCopyZip = new System.Windows.Forms.ProgressBar();
            this.lblBuildInstaller = new System.Windows.Forms.Label();
            this.progressBarInstaller = new System.Windows.Forms.ProgressBar();
            this.lblElapsedTimeFileVersion = new System.Windows.Forms.Label();
            this.lblElapsedTimeTM = new System.Windows.Forms.Label();
            this.lblElapsedTimeWeb = new System.Windows.Forms.Label();
            this.lblElapsedTimeCopyZips = new System.Windows.Forms.Label();
            this.lblElapsedTimeInstaller = new System.Windows.Forms.Label();
            this.chkOpenGitAfterBuild = new System.Windows.Forms.CheckBox();
            this.chkOpenOutputFolderAfterBuild = new System.Windows.Forms.CheckBox();
            this.lblStatusFileVersion = new System.Windows.Forms.Label();
            this.lblStatusTM = new System.Windows.Forms.Label();
            this.lblStatusWeb = new System.Windows.Forms.Label();
            this.lblStatusCopyZips = new System.Windows.Forms.Label();
            this.lblStatusInstaller = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSourcePath
            // 
            this.lblSourcePath.AutoSize = true;
            this.lblSourcePath.Location = new System.Drawing.Point(10, 29);
            this.lblSourcePath.Name = "lblSourcePath";
            this.lblSourcePath.Size = new System.Drawing.Size(150, 13);
            this.lblSourcePath.TabIndex = 0;
            this.lblSourcePath.Text = "Path to project /source/ folder";
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(159, 27);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(324, 20);
            this.txtSourcePath.TabIndex = 1;
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(487, 27);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(64, 20);
            this.btnBrowseSource.TabIndex = 2;
            this.btnBrowseSource.Text = "Browse...";
            this.btnBrowseSource.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtCurrentMajor
            // 
            this.txtCurrentMajor.Location = new System.Drawing.Point(92, 91);
            this.txtCurrentMajor.Name = "txtCurrentMajor";
            this.txtCurrentMajor.Size = new System.Drawing.Size(39, 20);
            this.txtCurrentMajor.TabIndex = 3;
            // 
            // txtCurrentMinor
            // 
            this.txtCurrentMinor.Location = new System.Drawing.Point(135, 91);
            this.txtCurrentMinor.Name = "txtCurrentMinor";
            this.txtCurrentMinor.Size = new System.Drawing.Size(39, 20);
            this.txtCurrentMinor.TabIndex = 4;
            // 
            // txtCurrentBuild
            // 
            this.txtCurrentBuild.Location = new System.Drawing.Point(179, 91);
            this.txtCurrentBuild.Name = "txtCurrentBuild";
            this.txtCurrentBuild.Size = new System.Drawing.Size(39, 20);
            this.txtCurrentBuild.TabIndex = 5;
            // 
            // txtCurrentRevision
            // 
            this.txtCurrentRevision.Location = new System.Drawing.Point(223, 91);
            this.txtCurrentRevision.Name = "txtCurrentRevision";
            this.txtCurrentRevision.Size = new System.Drawing.Size(39, 20);
            this.txtCurrentRevision.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Current version";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Next version";
            // 
            // txtNextRevision
            // 
            this.txtNextRevision.Location = new System.Drawing.Point(223, 124);
            this.txtNextRevision.Name = "txtNextRevision";
            this.txtNextRevision.Size = new System.Drawing.Size(39, 20);
            this.txtNextRevision.TabIndex = 11;
            // 
            // txtNextBuild
            // 
            this.txtNextBuild.Location = new System.Drawing.Point(179, 124);
            this.txtNextBuild.Name = "txtNextBuild";
            this.txtNextBuild.Size = new System.Drawing.Size(39, 20);
            this.txtNextBuild.TabIndex = 10;
            // 
            // txtNextMinor
            // 
            this.txtNextMinor.Location = new System.Drawing.Point(135, 124);
            this.txtNextMinor.Name = "txtNextMinor";
            this.txtNextMinor.Size = new System.Drawing.Size(39, 20);
            this.txtNextMinor.TabIndex = 9;
            // 
            // txtNextMajor
            // 
            this.txtNextMajor.Location = new System.Drawing.Point(92, 124);
            this.txtNextMajor.Name = "txtNextMajor";
            this.txtNextMajor.Size = new System.Drawing.Size(39, 20);
            this.txtNextMajor.TabIndex = 8;
            // 
            // btnBuildAndPackage
            // 
            this.btnBuildAndPackage.Location = new System.Drawing.Point(10, 261);
            this.btnBuildAndPackage.Name = "btnBuildAndPackage";
            this.btnBuildAndPackage.Size = new System.Drawing.Size(148, 49);
            this.btnBuildAndPackage.TabIndex = 14;
            this.btnBuildAndPackage.Text = "Build And Zip";
            this.btnBuildAndPackage.UseVisualStyleBackColor = true;
            this.btnBuildAndPackage.Click += new System.EventHandler(this.btnBuildAndPackage_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(159, 52);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(324, 20);
            this.txtOutputPath.TabIndex = 15;
            // 
            // txtOutputDestination
            // 
            this.txtOutputDestination.AutoSize = true;
            this.txtOutputDestination.Location = new System.Drawing.Point(10, 55);
            this.txtOutputDestination.Name = "txtOutputDestination";
            this.txtOutputDestination.Size = new System.Drawing.Size(124, 13);
            this.txtOutputDestination.TabIndex = 16;
            this.txtOutputDestination.Text = "Destination path for build";
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(487, 52);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(64, 20);
            this.btnBrowseOutput.TabIndex = 17;
            this.btnBrowseOutput.Text = "Browse...";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // progressBarUpdateFileVersions
            // 
            this.progressBarUpdateFileVersions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBarUpdateFileVersions.Location = new System.Drawing.Point(347, 193);
            this.progressBarUpdateFileVersions.Name = "progressBarUpdateFileVersions";
            this.progressBarUpdateFileVersions.Size = new System.Drawing.Size(109, 20);
            this.progressBarUpdateFileVersions.TabIndex = 18;
            // 
            // lblUpdateFileVersions
            // 
            this.lblUpdateFileVersions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUpdateFileVersions.AutoSize = true;
            this.lblUpdateFileVersions.Location = new System.Drawing.Point(240, 200);
            this.lblUpdateFileVersions.Name = "lblUpdateFileVersions";
            this.lblUpdateFileVersions.Size = new System.Drawing.Size(104, 13);
            this.lblUpdateFileVersions.TabIndex = 19;
            this.lblUpdateFileVersions.Text = "Update File Versions";
            // 
            // lblBuildTM
            // 
            this.lblBuildTM.AutoSize = true;
            this.lblBuildTM.Location = new System.Drawing.Point(254, 225);
            this.lblBuildTM.Name = "lblBuildTM";
            this.lblBuildTM.Size = new System.Drawing.Size(86, 13);
            this.lblBuildTM.TabIndex = 21;
            this.lblBuildTM.Text = "Build and zip TM";
            // 
            // progressBarTM
            // 
            this.progressBarTM.Location = new System.Drawing.Point(347, 218);
            this.progressBarTM.Name = "progressBarTM";
            this.progressBarTM.Size = new System.Drawing.Size(109, 20);
            this.progressBarTM.TabIndex = 20;
            // 
            // lblBuildWeb
            // 
            this.lblBuildWeb.AutoSize = true;
            this.lblBuildWeb.Location = new System.Drawing.Point(249, 250);
            this.lblBuildWeb.Name = "lblBuildWeb";
            this.lblBuildWeb.Size = new System.Drawing.Size(93, 13);
            this.lblBuildWeb.TabIndex = 23;
            this.lblBuildWeb.Text = "Build and zip Web";
            // 
            // progressBarWeb
            // 
            this.progressBarWeb.Location = new System.Drawing.Point(347, 244);
            this.progressBarWeb.Name = "progressBarWeb";
            this.progressBarWeb.Size = new System.Drawing.Size(109, 20);
            this.progressBarWeb.TabIndex = 22;
            // 
            // lblCopyZips
            // 
            this.lblCopyZips.AutoSize = true;
            this.lblCopyZips.Location = new System.Drawing.Point(203, 276);
            this.lblCopyZips.Name = "lblCopyZips";
            this.lblCopyZips.Size = new System.Drawing.Size(140, 13);
            this.lblCopyZips.TabIndex = 25;
            this.lblCopyZips.Text = "Add TM and web to Installer";
            // 
            // progressBarCopyZip
            // 
            this.progressBarCopyZip.Location = new System.Drawing.Point(347, 269);
            this.progressBarCopyZip.Name = "progressBarCopyZip";
            this.progressBarCopyZip.Size = new System.Drawing.Size(109, 20);
            this.progressBarCopyZip.TabIndex = 24;
            // 
            // lblBuildInstaller
            // 
            this.lblBuildInstaller.AutoSize = true;
            this.lblBuildInstaller.Location = new System.Drawing.Point(232, 301);
            this.lblBuildInstaller.Name = "lblBuildInstaller";
            this.lblBuildInstaller.Size = new System.Drawing.Size(109, 13);
            this.lblBuildInstaller.TabIndex = 27;
            this.lblBuildInstaller.Text = "Build and zip Installer ";
            // 
            // progressBarInstaller
            // 
            this.progressBarInstaller.Location = new System.Drawing.Point(347, 294);
            this.progressBarInstaller.Name = "progressBarInstaller";
            this.progressBarInstaller.Size = new System.Drawing.Size(109, 20);
            this.progressBarInstaller.TabIndex = 26;
            // 
            // lblElapsedTimeFileVersion
            // 
            this.lblElapsedTimeFileVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblElapsedTimeFileVersion.AutoSize = true;
            this.lblElapsedTimeFileVersion.Location = new System.Drawing.Point(461, 200);
            this.lblElapsedTimeFileVersion.Name = "lblElapsedTimeFileVersion";
            this.lblElapsedTimeFileVersion.Size = new System.Drawing.Size(43, 13);
            this.lblElapsedTimeFileVersion.TabIndex = 29;
            this.lblElapsedTimeFileVersion.Text = "Waiting";
            // 
            // lblElapsedTimeTM
            // 
            this.lblElapsedTimeTM.AutoSize = true;
            this.lblElapsedTimeTM.Location = new System.Drawing.Point(461, 225);
            this.lblElapsedTimeTM.Name = "lblElapsedTimeTM";
            this.lblElapsedTimeTM.Size = new System.Drawing.Size(43, 13);
            this.lblElapsedTimeTM.TabIndex = 30;
            this.lblElapsedTimeTM.Text = "Waiting";
            // 
            // lblElapsedTimeWeb
            // 
            this.lblElapsedTimeWeb.AutoSize = true;
            this.lblElapsedTimeWeb.Location = new System.Drawing.Point(461, 250);
            this.lblElapsedTimeWeb.Name = "lblElapsedTimeWeb";
            this.lblElapsedTimeWeb.Size = new System.Drawing.Size(43, 13);
            this.lblElapsedTimeWeb.TabIndex = 31;
            this.lblElapsedTimeWeb.Text = "Waiting";
            // 
            // lblElapsedTimeCopyZips
            // 
            this.lblElapsedTimeCopyZips.AutoSize = true;
            this.lblElapsedTimeCopyZips.Location = new System.Drawing.Point(461, 276);
            this.lblElapsedTimeCopyZips.Name = "lblElapsedTimeCopyZips";
            this.lblElapsedTimeCopyZips.Size = new System.Drawing.Size(43, 13);
            this.lblElapsedTimeCopyZips.TabIndex = 32;
            this.lblElapsedTimeCopyZips.Text = "Waiting";
            // 
            // lblElapsedTimeInstaller
            // 
            this.lblElapsedTimeInstaller.AutoSize = true;
            this.lblElapsedTimeInstaller.Location = new System.Drawing.Point(461, 301);
            this.lblElapsedTimeInstaller.Name = "lblElapsedTimeInstaller";
            this.lblElapsedTimeInstaller.Size = new System.Drawing.Size(43, 13);
            this.lblElapsedTimeInstaller.TabIndex = 33;
            this.lblElapsedTimeInstaller.Text = "Waiting";
            // 
            // chkOpenGitAfterBuild
            // 
            this.chkOpenGitAfterBuild.AutoSize = true;
            this.chkOpenGitAfterBuild.Checked = true;
            this.chkOpenGitAfterBuild.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenGitAfterBuild.Location = new System.Drawing.Point(10, 152);
            this.chkOpenGitAfterBuild.Name = "chkOpenGitAfterBuild";
            this.chkOpenGitAfterBuild.Size = new System.Drawing.Size(155, 17);
            this.chkOpenGitAfterBuild.TabIndex = 34;
            this.chkOpenGitAfterBuild.Text = "Open TortoiseGit after build";
            this.chkOpenGitAfterBuild.UseVisualStyleBackColor = true;
            this.chkOpenGitAfterBuild.CheckedChanged += new System.EventHandler(this.chkOpenGitAfterBuild_CheckedChanged);
            // 
            // chkOpenOutputFolderAfterBuild
            // 
            this.chkOpenOutputFolderAfterBuild.AutoSize = true;
            this.chkOpenOutputFolderAfterBuild.Location = new System.Drawing.Point(10, 173);
            this.chkOpenOutputFolderAfterBuild.Name = "chkOpenOutputFolderAfterBuild";
            this.chkOpenOutputFolderAfterBuild.Size = new System.Drawing.Size(177, 17);
            this.chkOpenOutputFolderAfterBuild.TabIndex = 35;
            this.chkOpenOutputFolderAfterBuild.Text = "Open output directory after build";
            this.chkOpenOutputFolderAfterBuild.UseVisualStyleBackColor = true;
            this.chkOpenOutputFolderAfterBuild.CheckedChanged += new System.EventHandler(this.chkOpenOutputFolderAfterBuild_CheckedChanged);
            // 
            // lblStatusFileVersion
            // 
            this.lblStatusFileVersion.AutoSize = true;
            this.lblStatusFileVersion.Location = new System.Drawing.Point(510, 200);
            this.lblStatusFileVersion.Name = "lblStatusFileVersion";
            this.lblStatusFileVersion.Size = new System.Drawing.Size(0, 13);
            this.lblStatusFileVersion.TabIndex = 36;
            // 
            // lblStatusTM
            // 
            this.lblStatusTM.AutoSize = true;
            this.lblStatusTM.Location = new System.Drawing.Point(507, 225);
            this.lblStatusTM.Name = "lblStatusTM";
            this.lblStatusTM.Size = new System.Drawing.Size(0, 13);
            this.lblStatusTM.TabIndex = 37;
            // 
            // lblStatusWeb
            // 
            this.lblStatusWeb.AutoSize = true;
            this.lblStatusWeb.Location = new System.Drawing.Point(507, 250);
            this.lblStatusWeb.Name = "lblStatusWeb";
            this.lblStatusWeb.Size = new System.Drawing.Size(0, 13);
            this.lblStatusWeb.TabIndex = 38;
            // 
            // lblStatusCopyZips
            // 
            this.lblStatusCopyZips.AutoSize = true;
            this.lblStatusCopyZips.Location = new System.Drawing.Point(508, 276);
            this.lblStatusCopyZips.Name = "lblStatusCopyZips";
            this.lblStatusCopyZips.Size = new System.Drawing.Size(0, 13);
            this.lblStatusCopyZips.TabIndex = 39;
            // 
            // lblStatusInstaller
            // 
            this.lblStatusInstaller.AutoSize = true;
            this.lblStatusInstaller.Location = new System.Drawing.Point(507, 301);
            this.lblStatusInstaller.Name = "lblStatusInstaller";
            this.lblStatusInstaller.Size = new System.Drawing.Size(0, 13);
            this.lblStatusInstaller.TabIndex = 40;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 331);
            this.Controls.Add(this.lblStatusInstaller);
            this.Controls.Add(this.lblStatusCopyZips);
            this.Controls.Add(this.lblStatusWeb);
            this.Controls.Add(this.lblStatusTM);
            this.Controls.Add(this.lblStatusFileVersion);
            this.Controls.Add(this.chkOpenOutputFolderAfterBuild);
            this.Controls.Add(this.chkOpenGitAfterBuild);
            this.Controls.Add(this.lblElapsedTimeInstaller);
            this.Controls.Add(this.lblElapsedTimeCopyZips);
            this.Controls.Add(this.lblElapsedTimeWeb);
            this.Controls.Add(this.lblElapsedTimeTM);
            this.Controls.Add(this.lblElapsedTimeFileVersion);
            this.Controls.Add(this.lblBuildInstaller);
            this.Controls.Add(this.progressBarInstaller);
            this.Controls.Add(this.lblCopyZips);
            this.Controls.Add(this.progressBarCopyZip);
            this.Controls.Add(this.lblBuildWeb);
            this.Controls.Add(this.progressBarWeb);
            this.Controls.Add(this.lblBuildTM);
            this.Controls.Add(this.progressBarTM);
            this.Controls.Add(this.lblUpdateFileVersions);
            this.Controls.Add(this.progressBarUpdateFileVersions);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.txtOutputDestination);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.btnBuildAndPackage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNextRevision);
            this.Controls.Add(this.txtNextBuild);
            this.Controls.Add(this.txtNextMinor);
            this.Controls.Add(this.txtNextMajor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrentRevision);
            this.Controls.Add(this.txtCurrentBuild);
            this.Controls.Add(this.txtCurrentMinor);
            this.Controls.Add(this.txtCurrentMajor);
            this.Controls.Add(this.btnBrowseSource);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.lblSourcePath);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

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
