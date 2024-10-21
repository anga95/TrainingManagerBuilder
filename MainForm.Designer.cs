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
        ///  DeleteInstallerBinDirectory up any resources being used.
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
            this.btnRebuildAndPackage = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.txtOutputDestination = new System.Windows.Forms.Label();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.progressBarUpdateFileVersions = new System.Windows.Forms.ProgressBar();
            this.lblUpdateFileVersions = new System.Windows.Forms.Label();
            this.lblBuildWeb = new System.Windows.Forms.Label();
            this.progressBarWeb = new System.Windows.Forms.ProgressBar();
            this.lblCopyZips = new System.Windows.Forms.Label();
            this.progressBarCopyZip = new System.Windows.Forms.ProgressBar();
            this.lblBuildInstaller = new System.Windows.Forms.Label();
            this.progressBarInstaller = new System.Windows.Forms.ProgressBar();
            this.lblElapsedTimeFileVersion = new System.Windows.Forms.Label();
            this.lblElapsedTimeWeb = new System.Windows.Forms.Label();
            this.lblElapsedTimeCopyZips = new System.Windows.Forms.Label();
            this.lblElapsedTimeInstaller = new System.Windows.Forms.Label();
            this.chkOpenGitAfterBuild = new System.Windows.Forms.CheckBox();
            this.chkOpenOutputFolderAfterBuild = new System.Windows.Forms.CheckBox();
            this.lblStatusFileVersion = new System.Windows.Forms.Label();
            this.lblStatusWeb = new System.Windows.Forms.Label();
            this.lblStatusCopyZips = new System.Windows.Forms.Label();
            this.lblStatusInstaller = new System.Windows.Forms.Label();
            this.chkRememberSource = new System.Windows.Forms.CheckBox();
            this.chkRememberOutputPath = new System.Windows.Forms.CheckBox();
            this.gbProgress = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuildTM = new System.Windows.Forms.Label();
            this.lblStatusTM = new System.Windows.Forms.Label();
            this.progressBarTM = new System.Windows.Forms.ProgressBar();
            this.lblElapsedTimeTM = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpVersions = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.gbVersions = new System.Windows.Forms.GroupBox();
            this.gbPaths = new System.Windows.Forms.GroupBox();
            this.gbProgress.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpVersions.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbVersions.SuspendLayout();
            this.gbPaths.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSourcePath
            // 
            this.lblSourcePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSourcePath.AutoSize = true;
            this.lblSourcePath.Location = new System.Drawing.Point(3, 6);
            this.lblSourcePath.Name = "lblSourcePath";
            this.lblSourcePath.Size = new System.Drawing.Size(150, 13);
            this.lblSourcePath.TabIndex = 0;
            this.lblSourcePath.Text = "Path to project /source/ folder";
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSourcePath.Location = new System.Drawing.Point(176, 3);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(297, 20);
            this.txtSourcePath.TabIndex = 1;
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseSource.Location = new System.Drawing.Point(479, 3);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(64, 19);
            this.btnBrowseSource.TabIndex = 2;
            this.btnBrowseSource.Text = "Browse...";
            this.btnBrowseSource.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtCurrentMajor
            // 
            this.txtCurrentMajor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCurrentMajor.Location = new System.Drawing.Point(53, 10);
            this.txtCurrentMajor.Name = "txtCurrentMajor";
            this.txtCurrentMajor.Size = new System.Drawing.Size(39, 20);
            this.txtCurrentMajor.TabIndex = 3;
            // 
            // txtCurrentMinor
            // 
            this.txtCurrentMinor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCurrentMinor.Location = new System.Drawing.Point(98, 10);
            this.txtCurrentMinor.Name = "txtCurrentMinor";
            this.txtCurrentMinor.Size = new System.Drawing.Size(39, 20);
            this.txtCurrentMinor.TabIndex = 4;
            // 
            // txtCurrentBuild
            // 
            this.txtCurrentBuild.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCurrentBuild.Location = new System.Drawing.Point(143, 10);
            this.txtCurrentBuild.Name = "txtCurrentBuild";
            this.txtCurrentBuild.Size = new System.Drawing.Size(39, 20);
            this.txtCurrentBuild.TabIndex = 5;
            // 
            // txtCurrentRevision
            // 
            this.txtCurrentRevision.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCurrentRevision.Location = new System.Drawing.Point(188, 10);
            this.txtCurrentRevision.Name = "txtCurrentRevision";
            this.txtCurrentRevision.Size = new System.Drawing.Size(39, 20);
            this.txtCurrentRevision.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Current version";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Next version";
            // 
            // txtNextRevision
            // 
            this.txtNextRevision.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNextRevision.Location = new System.Drawing.Point(188, 50);
            this.txtNextRevision.Name = "txtNextRevision";
            this.txtNextRevision.Size = new System.Drawing.Size(39, 20);
            this.txtNextRevision.TabIndex = 11;
            // 
            // txtNextBuild
            // 
            this.txtNextBuild.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNextBuild.Location = new System.Drawing.Point(143, 50);
            this.txtNextBuild.Name = "txtNextBuild";
            this.txtNextBuild.Size = new System.Drawing.Size(39, 20);
            this.txtNextBuild.TabIndex = 10;
            // 
            // txtNextMinor
            // 
            this.txtNextMinor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNextMinor.Location = new System.Drawing.Point(98, 50);
            this.txtNextMinor.Name = "txtNextMinor";
            this.txtNextMinor.Size = new System.Drawing.Size(39, 20);
            this.txtNextMinor.TabIndex = 9;
            // 
            // txtNextMajor
            // 
            this.txtNextMajor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNextMajor.Location = new System.Drawing.Point(53, 50);
            this.txtNextMajor.Name = "txtNextMajor";
            this.txtNextMajor.Size = new System.Drawing.Size(39, 20);
            this.txtNextMajor.TabIndex = 8;
            // 
            // btnRebuildAndPackage
            // 
            this.btnRebuildAndPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRebuildAndPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRebuildAndPackage.Location = new System.Drawing.Point(47, 268);
            this.btnRebuildAndPackage.Name = "btnRebuildAndPackage";
            this.btnRebuildAndPackage.Size = new System.Drawing.Size(171, 64);
            this.btnRebuildAndPackage.TabIndex = 14;
            this.btnRebuildAndPackage.Text = "Rebuild And Zip";
            this.btnRebuildAndPackage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRebuildAndPackage.UseVisualStyleBackColor = true;
            this.btnRebuildAndPackage.Click += new System.EventHandler(this.btnRebuildAndPackage_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOutputPath.Location = new System.Drawing.Point(176, 28);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(297, 20);
            this.txtOutputPath.TabIndex = 15;
            // 
            // txtOutputDestination
            // 
            this.txtOutputDestination.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOutputDestination.AutoSize = true;
            this.txtOutputDestination.Location = new System.Drawing.Point(3, 31);
            this.txtOutputDestination.Name = "txtOutputDestination";
            this.txtOutputDestination.Size = new System.Drawing.Size(124, 13);
            this.txtOutputDestination.TabIndex = 16;
            this.txtOutputDestination.Text = "Destination path for build";
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowseOutput.Location = new System.Drawing.Point(479, 28);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(64, 19);
            this.btnBrowseOutput.TabIndex = 17;
            this.btnBrowseOutput.Text = "Browse...";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // progressBarUpdateFileVersions
            // 
            this.progressBarUpdateFileVersions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBarUpdateFileVersions.Location = new System.Drawing.Point(115, 5);
            this.progressBarUpdateFileVersions.Name = "progressBarUpdateFileVersions";
            this.progressBarUpdateFileVersions.Size = new System.Drawing.Size(89, 20);
            this.progressBarUpdateFileVersions.TabIndex = 18;
            // 
            // lblUpdateFileVersions
            // 
            this.lblUpdateFileVersions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUpdateFileVersions.AutoSize = true;
            this.lblUpdateFileVersions.Location = new System.Drawing.Point(3, 8);
            this.lblUpdateFileVersions.Name = "lblUpdateFileVersions";
            this.lblUpdateFileVersions.Size = new System.Drawing.Size(104, 13);
            this.lblUpdateFileVersions.TabIndex = 19;
            this.lblUpdateFileVersions.Text = "Update File Versions";
            // 
            // lblBuildWeb
            // 
            this.lblBuildWeb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBuildWeb.AutoSize = true;
            this.lblBuildWeb.Location = new System.Drawing.Point(3, 38);
            this.lblBuildWeb.Name = "lblBuildWeb";
            this.lblBuildWeb.Size = new System.Drawing.Size(93, 13);
            this.lblBuildWeb.TabIndex = 23;
            this.lblBuildWeb.Text = "Build and zip Web";
            // 
            // progressBarWeb
            // 
            this.progressBarWeb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBarWeb.Location = new System.Drawing.Point(115, 35);
            this.progressBarWeb.Name = "progressBarWeb";
            this.progressBarWeb.Size = new System.Drawing.Size(89, 20);
            this.progressBarWeb.TabIndex = 22;
            // 
            // lblCopyZips
            // 
            this.lblCopyZips.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCopyZips.AutoSize = true;
            this.lblCopyZips.Location = new System.Drawing.Point(3, 92);
            this.lblCopyZips.Name = "lblCopyZips";
            this.lblCopyZips.Size = new System.Drawing.Size(104, 26);
            this.lblCopyZips.TabIndex = 25;
            this.lblCopyZips.Text = "Add TM and web to Installer";
            // 
            // progressBarCopyZip
            // 
            this.progressBarCopyZip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBarCopyZip.Location = new System.Drawing.Point(115, 95);
            this.progressBarCopyZip.Name = "progressBarCopyZip";
            this.progressBarCopyZip.Size = new System.Drawing.Size(89, 20);
            this.progressBarCopyZip.TabIndex = 24;
            // 
            // lblBuildInstaller
            // 
            this.lblBuildInstaller.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBuildInstaller.AutoSize = true;
            this.lblBuildInstaller.Location = new System.Drawing.Point(3, 128);
            this.lblBuildInstaller.Name = "lblBuildInstaller";
            this.lblBuildInstaller.Size = new System.Drawing.Size(106, 13);
            this.lblBuildInstaller.TabIndex = 27;
            this.lblBuildInstaller.Text = "Build and zip Installer ";
            // 
            // progressBarInstaller
            // 
            this.progressBarInstaller.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBarInstaller.Location = new System.Drawing.Point(115, 125);
            this.progressBarInstaller.Name = "progressBarInstaller";
            this.progressBarInstaller.Size = new System.Drawing.Size(89, 20);
            this.progressBarInstaller.TabIndex = 26;
            // 
            // lblElapsedTimeFileVersion
            // 
            this.lblElapsedTimeFileVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblElapsedTimeFileVersion.AutoSize = true;
            this.lblElapsedTimeFileVersion.Location = new System.Drawing.Point(210, 8);
            this.lblElapsedTimeFileVersion.Name = "lblElapsedTimeFileVersion";
            this.lblElapsedTimeFileVersion.Size = new System.Drawing.Size(43, 13);
            this.lblElapsedTimeFileVersion.TabIndex = 29;
            this.lblElapsedTimeFileVersion.Text = "Waiting";
            // 
            // lblElapsedTimeWeb
            // 
            this.lblElapsedTimeWeb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblElapsedTimeWeb.AutoSize = true;
            this.lblElapsedTimeWeb.Location = new System.Drawing.Point(210, 38);
            this.lblElapsedTimeWeb.Name = "lblElapsedTimeWeb";
            this.lblElapsedTimeWeb.Size = new System.Drawing.Size(43, 13);
            this.lblElapsedTimeWeb.TabIndex = 31;
            this.lblElapsedTimeWeb.Text = "Waiting";
            // 
            // lblElapsedTimeCopyZips
            // 
            this.lblElapsedTimeCopyZips.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblElapsedTimeCopyZips.AutoSize = true;
            this.lblElapsedTimeCopyZips.Location = new System.Drawing.Point(210, 98);
            this.lblElapsedTimeCopyZips.Name = "lblElapsedTimeCopyZips";
            this.lblElapsedTimeCopyZips.Size = new System.Drawing.Size(43, 13);
            this.lblElapsedTimeCopyZips.TabIndex = 32;
            this.lblElapsedTimeCopyZips.Text = "Waiting";
            // 
            // lblElapsedTimeInstaller
            // 
            this.lblElapsedTimeInstaller.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblElapsedTimeInstaller.AutoSize = true;
            this.lblElapsedTimeInstaller.Location = new System.Drawing.Point(210, 128);
            this.lblElapsedTimeInstaller.Name = "lblElapsedTimeInstaller";
            this.lblElapsedTimeInstaller.Size = new System.Drawing.Size(43, 13);
            this.lblElapsedTimeInstaller.TabIndex = 33;
            this.lblElapsedTimeInstaller.Text = "Waiting";
            // 
            // chkOpenGitAfterBuild
            // 
            this.chkOpenGitAfterBuild.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkOpenGitAfterBuild.AutoSize = true;
            this.chkOpenGitAfterBuild.Checked = true;
            this.chkOpenGitAfterBuild.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenGitAfterBuild.Location = new System.Drawing.Point(3, 12);
            this.chkOpenGitAfterBuild.Name = "chkOpenGitAfterBuild";
            this.chkOpenGitAfterBuild.Size = new System.Drawing.Size(155, 17);
            this.chkOpenGitAfterBuild.TabIndex = 34;
            this.chkOpenGitAfterBuild.Text = "Open TortoiseGit after build";
            this.chkOpenGitAfterBuild.UseVisualStyleBackColor = true;
            this.chkOpenGitAfterBuild.CheckedChanged += new System.EventHandler(this.chkOpenGitAfterBuild_CheckedChanged);
            // 
            // chkOpenOutputFolderAfterBuild
            // 
            this.chkOpenOutputFolderAfterBuild.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkOpenOutputFolderAfterBuild.AutoSize = true;
            this.chkOpenOutputFolderAfterBuild.Location = new System.Drawing.Point(3, 54);
            this.chkOpenOutputFolderAfterBuild.Name = "chkOpenOutputFolderAfterBuild";
            this.chkOpenOutputFolderAfterBuild.Size = new System.Drawing.Size(164, 17);
            this.chkOpenOutputFolderAfterBuild.TabIndex = 35;
            this.chkOpenOutputFolderAfterBuild.Text = "Open output directory after build";
            this.chkOpenOutputFolderAfterBuild.UseVisualStyleBackColor = true;
            this.chkOpenOutputFolderAfterBuild.CheckedChanged += new System.EventHandler(this.chkOpenOutputFolderAfterBuild_CheckedChanged);
            // 
            // lblStatusFileVersion
            // 
            this.lblStatusFileVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatusFileVersion.AutoSize = true;
            this.lblStatusFileVersion.Location = new System.Drawing.Point(269, 8);
            this.lblStatusFileVersion.Name = "lblStatusFileVersion";
            this.lblStatusFileVersion.Size = new System.Drawing.Size(62, 13);
            this.lblStatusFileVersion.TabIndex = 36;
            this.lblStatusFileVersion.Text = "placeholder";
            // 
            // lblStatusWeb
            // 
            this.lblStatusWeb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatusWeb.AutoSize = true;
            this.lblStatusWeb.Location = new System.Drawing.Point(269, 38);
            this.lblStatusWeb.Name = "lblStatusWeb";
            this.lblStatusWeb.Size = new System.Drawing.Size(62, 13);
            this.lblStatusWeb.TabIndex = 38;
            this.lblStatusWeb.Text = "placeholder";
            // 
            // lblStatusCopyZips
            // 
            this.lblStatusCopyZips.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatusCopyZips.AutoSize = true;
            this.lblStatusCopyZips.Location = new System.Drawing.Point(269, 98);
            this.lblStatusCopyZips.Name = "lblStatusCopyZips";
            this.lblStatusCopyZips.Size = new System.Drawing.Size(62, 13);
            this.lblStatusCopyZips.TabIndex = 39;
            this.lblStatusCopyZips.Text = "placeholder";
            // 
            // lblStatusInstaller
            // 
            this.lblStatusInstaller.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatusInstaller.AutoSize = true;
            this.lblStatusInstaller.Location = new System.Drawing.Point(269, 128);
            this.lblStatusInstaller.Name = "lblStatusInstaller";
            this.lblStatusInstaller.Size = new System.Drawing.Size(62, 13);
            this.lblStatusInstaller.TabIndex = 40;
            this.lblStatusInstaller.Text = "placeholder";
            // 
            // chkRememberSource
            // 
            this.chkRememberSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkRememberSource.AutoSize = true;
            this.chkRememberSource.Location = new System.Drawing.Point(173, 12);
            this.chkRememberSource.Name = "chkRememberSource";
            this.chkRememberSource.Size = new System.Drawing.Size(136, 17);
            this.chkRememberSource.TabIndex = 41;
            this.chkRememberSource.Text = "Remember source path";
            this.chkRememberSource.UseVisualStyleBackColor = true;
            this.chkRememberSource.CheckedChanged += new System.EventHandler(this.chkRememberSource_CheckedChanged);
            // 
            // chkRememberOutputPath
            // 
            this.chkRememberOutputPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkRememberOutputPath.AutoSize = true;
            this.chkRememberOutputPath.Location = new System.Drawing.Point(173, 54);
            this.chkRememberOutputPath.Name = "chkRememberOutputPath";
            this.chkRememberOutputPath.Size = new System.Drawing.Size(157, 17);
            this.chkRememberOutputPath.TabIndex = 42;
            this.chkRememberOutputPath.Text = "Rememeber output directory";
            this.chkRememberOutputPath.UseVisualStyleBackColor = true;
            this.chkRememberOutputPath.CheckedChanged += new System.EventHandler(this.chkRememberOutputPath_CheckedChanged);
            // 
            // gbProgress
            // 
            this.gbProgress.Controls.Add(this.tableLayoutPanel1);
            this.gbProgress.Location = new System.Drawing.Point(274, 210);
            this.gbProgress.Name = "gbProgress";
            this.gbProgress.Size = new System.Drawing.Size(358, 174);
            this.gbProgress.TabIndex = 43;
            this.gbProgress.TabStop = false;
            this.gbProgress.Text = "Progress";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.Controls.Add(this.lblBuildTM, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblStatusTM, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.progressBarTM, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblElapsedTimeTM, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblStatusInstaller, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblStatusCopyZips, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblUpdateFileVersions, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStatusWeb, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBarUpdateFileVersions, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStatusFileVersion, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBarCopyZip, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblElapsedTimeInstaller, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.progressBarWeb, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBuildWeb, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblElapsedTimeWeb, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBarInstaller, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblElapsedTimeCopyZips, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblElapsedTimeFileVersion, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCopyZips, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblBuildInstaller, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(339, 145);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // lblBuildTM
            // 
            this.lblBuildTM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBuildTM.AutoSize = true;
            this.lblBuildTM.Location = new System.Drawing.Point(3, 68);
            this.lblBuildTM.Name = "lblBuildTM";
            this.lblBuildTM.Size = new System.Drawing.Size(86, 13);
            this.lblBuildTM.TabIndex = 50;
            this.lblBuildTM.Text = "Build and zip TM";
            // 
            // lblStatusTM
            // 
            this.lblStatusTM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatusTM.AutoSize = true;
            this.lblStatusTM.Location = new System.Drawing.Point(269, 68);
            this.lblStatusTM.Name = "lblStatusTM";
            this.lblStatusTM.Size = new System.Drawing.Size(62, 13);
            this.lblStatusTM.TabIndex = 52;
            this.lblStatusTM.Text = "placeholder";
            // 
            // progressBarTM
            // 
            this.progressBarTM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBarTM.Location = new System.Drawing.Point(115, 65);
            this.progressBarTM.Name = "progressBarTM";
            this.progressBarTM.Size = new System.Drawing.Size(89, 20);
            this.progressBarTM.TabIndex = 49;
            // 
            // lblElapsedTimeTM
            // 
            this.lblElapsedTimeTM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblElapsedTimeTM.AutoSize = true;
            this.lblElapsedTimeTM.Location = new System.Drawing.Point(210, 68);
            this.lblElapsedTimeTM.Name = "lblElapsedTimeTM";
            this.lblElapsedTimeTM.Size = new System.Drawing.Size(43, 13);
            this.lblElapsedTimeTM.TabIndex = 51;
            this.lblElapsedTimeTM.Text = "Waiting";
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.tableLayoutPanel2);
            this.gbSettings.Location = new System.Drawing.Point(283, 94);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(349, 110);
            this.gbSettings.TabIndex = 44;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.75F));
            this.tableLayoutPanel2.Controls.Add(this.chkOpenGitAfterBuild, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkOpenOutputFolderAfterBuild, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkRememberSource, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkRememberOutputPath, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(333, 84);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tlpVersions
            // 
            this.tlpVersions.ColumnCount = 5;
            this.tlpVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpVersions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpVersions.Controls.Add(this.label1, 0, 0);
            this.tlpVersions.Controls.Add(this.label2, 0, 1);
            this.tlpVersions.Controls.Add(this.txtCurrentMajor, 1, 0);
            this.tlpVersions.Controls.Add(this.txtCurrentMinor, 2, 0);
            this.tlpVersions.Controls.Add(this.txtCurrentBuild, 3, 0);
            this.tlpVersions.Controls.Add(this.txtCurrentRevision, 4, 0);
            this.tlpVersions.Controls.Add(this.txtNextMajor, 1, 1);
            this.tlpVersions.Controls.Add(this.txtNextRevision, 4, 1);
            this.tlpVersions.Controls.Add(this.txtNextMinor, 2, 1);
            this.tlpVersions.Controls.Add(this.txtNextBuild, 3, 1);
            this.tlpVersions.Location = new System.Drawing.Point(6, 19);
            this.tlpVersions.Name = "tlpVersions";
            this.tlpVersions.RowCount = 2;
            this.tlpVersions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVersions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVersions.Size = new System.Drawing.Size(238, 81);
            this.tlpVersions.TabIndex = 45;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.30137F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.69863F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel3.Controls.Add(this.lblSourcePath, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSourcePath, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBrowseSource, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtOutputDestination, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnBrowseOutput, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtOutputPath, 1, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(600, 50);
            this.tableLayoutPanel3.TabIndex = 46;
            // 
            // gbVersions
            // 
            this.gbVersions.Controls.Add(this.tlpVersions);
            this.gbVersions.Location = new System.Drawing.Point(16, 94);
            this.gbVersions.Name = "gbVersions";
            this.gbVersions.Size = new System.Drawing.Size(252, 110);
            this.gbVersions.TabIndex = 47;
            this.gbVersions.TabStop = false;
            this.gbVersions.Text = "Version";
            // 
            // gbPaths
            // 
            this.gbPaths.Controls.Add(this.tableLayoutPanel3);
            this.gbPaths.Location = new System.Drawing.Point(16, 8);
            this.gbPaths.Name = "gbPaths";
            this.gbPaths.Size = new System.Drawing.Size(616, 80);
            this.gbPaths.TabIndex = 48;
            this.gbPaths.TabStop = false;
            this.gbPaths.Text = "Paths";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 396);
            this.Controls.Add(this.gbPaths);
            this.Controls.Add(this.gbVersions);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.gbProgress);
            this.Controls.Add(this.btnRebuildAndPackage);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.gbProgress.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tlpVersions.ResumeLayout(false);
            this.tlpVersions.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.gbVersions.ResumeLayout(false);
            this.gbPaths.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private Button btnRebuildAndPackage;
        private TextBox txtOutputPath;
        private Label txtOutputDestination;
        private Button btnBrowseOutput;
        private ProgressBar progressBarUpdateFileVersions;
        private Label lblUpdateFileVersions;
        private Label lblBuildWeb;
        private ProgressBar progressBarWeb;
        private Label lblCopyZips;
        private ProgressBar progressBarCopyZip;
        private Label lblBuildInstaller;
        private ProgressBar progressBarInstaller;
        private Label lblElapsedTimeFileVersion;
        private Label lblElapsedTimeWeb;
        private Label lblElapsedTimeCopyZips;
        private Label lblElapsedTimeInstaller;
        private CheckBox chkOpenGitAfterBuild;
        private CheckBox chkOpenOutputFolderAfterBuild;
        private Label lblStatusFileVersion;
        private Label lblStatusWeb;
        private Label lblStatusCopyZips;
        private Label lblStatusInstaller;
        private CheckBox chkRememberSource;
        private CheckBox chkRememberOutputPath;
        private GroupBox gbProgress;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox gbSettings;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tlpVersions;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox gbVersions;
        private GroupBox gbPaths;
        private Label lblBuildTM;
        private Label lblStatusTM;
        private ProgressBar progressBarTM;
        private Label lblElapsedTimeTM;
    }
}
