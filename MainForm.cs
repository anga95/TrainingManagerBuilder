using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TrainingManagerBuilder
{
    public partial class MainForm : Form
    {
        private VersionManager versionManager;

        private ZipUtilities zipUtilities;
        private UserSettings settings;
        private Dictionary<string, ProgressStepManager> progressSteps;
        private bool isLoadingSettings = false;

        public MainForm()
        {
            InitializeComponent();
            settings = UserSettings.Instance;

            this.Icon = new Icon(AppDomain.CurrentDomain.BaseDirectory + "svincoolvalmetlogga.ico");
            this.Text = "Training Manager Builder";
            btnBuildAndPackage.Enabled = false;

            isLoadingSettings = true;
            chkOpenGitAfterBuild.Enabled = settings.IsTortoiseGitAvailable;
            chkOpenGitAfterBuild.Checked = settings.OpenTortoiseGitAfterBuild;
            chkOpenOutputFolderAfterBuild.Checked = settings.OpenOutputDirectoryAfterBuild;

            chkRememberSource.Checked = settings.RememberSourcePath;
            chkRememberOutputPath.Checked = settings.RememberOutputPath;
            if (settings.RememberSourcePath)
            {
                txtSourcePath.Text = settings.SourcePath;
                if (IsValidSourcePath(txtSourcePath.Text))
                {
                    LoadVersion();
                }
            }
            if (settings.RememberOutputPath)
            {
                txtOutputPath.Text = settings.OutputPath;
            }
            isLoadingSettings = false;

            progressSteps = new Dictionary<string, ProgressStepManager>
            {
                { "UpdateFileVersions", new ProgressStepManager(lblUpdateFileVersions, progressBarUpdateFileVersions, lblElapsedTimeFileVersion, lblStatusFileVersion) },
                { "BuildTM", new ProgressStepManager(lblBuildTM, progressBarTM, lblElapsedTimeTM, lblStatusTM) },
                { "BuildWeb", new ProgressStepManager(lblBuildWeb, progressBarWeb, lblElapsedTimeWeb, lblStatusWeb) },
                { "copyZips", new ProgressStepManager(lblCopyZips, progressBarCopyZip, lblElapsedTimeCopyZips, lblStatusCopyZips) },
                { "BuildInstaller", new ProgressStepManager(lblBuildInstaller, progressBarInstaller, lblElapsedTimeInstaller, lblStatusInstaller) }
            };

            zipUtilities = new ZipUtilities();
        }

        private void LoadVersion()
        {
            versionManager = new VersionManager(txtSourcePath.Text);
            LoadCurrentVersion();

            btnBuildAndPackage.Enabled = true;

            if (chkRememberSource.Checked)
            {
                settings.SourcePath = txtSourcePath.Text;
            }
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new OpenFileDialog())
            {
                folderBrowser.ValidateNames = false;
                folderBrowser.CheckFileExists = false;
                folderBrowser.CheckPathExists = true;
                folderBrowser.FileName = "Select Folder";

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtSourcePath.Text = System.IO.Path.GetDirectoryName(folderBrowser.FileName);

                    // Validate the selected folder
                    if (IsValidSourcePath(txtSourcePath.Text))
                    {
                        LoadVersion();
                    }
                    else
                    {
                        MessageBox.Show("The selected folder does not contain a valid solution file (.sln).\nPlease select a correct folder.",
                            "Invalid Folder",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnBuildAndPackage.Enabled = false;
                    }
                }
            }
        }
        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new OpenFileDialog())
            {
                folderBrowser.ValidateNames = false;
                folderBrowser.CheckFileExists = false;
                folderBrowser.CheckPathExists = true;
                folderBrowser.FileName = "Select Folder";

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = System.IO.Path.GetDirectoryName(folderBrowser.FileName);
                    txtOutputPath.Text = folderPath;

                    if (chkRememberOutputPath.Checked)
                    {
                        settings.OutputPath = txtOutputPath.Text;
                    }
                }
            }
        }

        private bool IsValidSourcePath(string folderPath)
        {
            // Check if the folder contains a .sln file
            var solutionFiles = Directory.GetFiles(folderPath, "*.sln");
            return solutionFiles.Length > 0;
        }

        private void LoadCurrentVersion()
        {
            var currentVersion = versionManager.GetCurrentVersion();
            txtCurrentMajor.Text = currentVersion.Major.ToString();
            txtCurrentMinor.Text = currentVersion.Minor.ToString();
            txtCurrentBuild.Text = currentVersion.Build.ToString();
            txtCurrentRevision.Text = currentVersion.Revision.ToString();

            var nextVersion = versionManager.GetNextVersion(currentVersion.Major, currentVersion.Minor, currentVersion.Build, currentVersion.Revision);
            txtNextMajor.Text = nextVersion.Major.ToString();
            txtNextMinor.Text = nextVersion.Minor.ToString();
            txtNextBuild.Text = nextVersion.Build.ToString();
            txtNextRevision.Text = nextVersion.Revision.ToString();
        }




        public void SetTimersToWaiting()
        {
            string waiting = "Waiting...";
            lblElapsedTimeFileVersion.Text = waiting;
            lblElapsedTimeTM.Text = waiting;
            lblElapsedTimeWeb.Text = waiting;
            lblElapsedTimeCopyZips.Text = waiting;
            lblElapsedTimeInstaller.Text = waiting;
        }

        private async void btnBuildAndPackage_Click(object sender, EventArgs e)
        {
            LockControls();

            string oldVersion = $"{txtCurrentMajor.Text}.{txtCurrentMinor.Text}.{txtCurrentBuild.Text}.{txtCurrentRevision.Text}";
            string newVersion = $"{txtNextMajor.Text}.{txtNextMinor.Text}.{txtNextBuild.Text}.{txtNextRevision.Text}";

            try
            {
                BuildManager buildManager = new BuildManager(txtSourcePath.Text, zipUtilities, progressSteps);

                // Build and package the project
                await buildManager.BuildAndPackage(
                    txtOutputPath.Text,
                    txtSourcePath.Text,
                    oldVersion,
                    newVersion
                );

                // Open TortoiseGit after build, if selected
                if (chkOpenGitAfterBuild.Checked)
                {
                    TortoiseGitHelper gitHelper = new TortoiseGitHelper();
                    gitHelper.OpenCommitDialog(txtSourcePath.Text, newVersion);
                }

                // Open output folder after build, if selected
                if (chkOpenOutputFolderAfterBuild.Checked)
                {
                    OpenOutputFolder(txtOutputPath.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UnlockControls();
            }

        }

        private void SetControlState(bool isEnabled)
        {
            var controls = new List<Control>
            {
                btnBuildAndPackage, btnBrowseSource, btnBrowseOutput, txtSourcePath, txtOutputPath,
                txtCurrentMajor, txtCurrentMinor, txtCurrentBuild, txtCurrentRevision,
                txtNextMajor, txtNextMinor, txtNextBuild, txtNextRevision
            };

            foreach (var control in controls)
            {
                control.Enabled = isEnabled;
            }
        }

        private void LockControls()
        {
            SetControlState(false);
        }

        private void UnlockControls()
        {
            SetControlState(true);
        }

        private void ResetProgressBars()
        {
            progressBarTM.Value = 0;
            progressBarTM.Maximum = 2;
            progressBarWeb.Value = 0;
            progressBarWeb.Maximum = 2;
            progressBarCopyZip.Value = 0;
            progressBarCopyZip.Maximum = 2;
            progressBarInstaller.Value = 0;
            progressBarInstaller.Maximum = 2;
        }

        private void OpenOutputFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                Process.Start("explorer.exe", folderPath);
                Logger.Log($"Opened folder: {folderPath}");
            }
            else
            {
                Logger.LogError($"Could not open folder. Path does not exist: {folderPath}");
            }
        }

        private void chkOpenGitAfterBuild_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoadingSettings) return;

            settings.OpenTortoiseGitAfterBuild = chkOpenGitAfterBuild.Checked;
        }

        private void chkOpenOutputFolderAfterBuild_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoadingSettings) return;

            settings.OpenOutputDirectoryAfterBuild = chkOpenOutputFolderAfterBuild.Checked;
        }

        private void chkRememberSource_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoadingSettings) return;

            settings.RememberSourcePath = chkRememberSource.Checked;
            settings.SourcePath = txtSourcePath.Text;
        }

        private void chkRememberOutputPath_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoadingSettings) return;

            settings.RememberOutputPath = chkRememberOutputPath.Checked;
            settings.OutputPath = txtOutputPath.Text;
        }
    }
}
