using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace TrainingManagerBuilder
{
    public partial class MainForm : Form
    {
        private VersionManager versionManager;
        private UserSettings settings;
        private Dictionary<string, ProgressStepManager> progressSteps;
        private bool isLoadingSettings = false;

        private System.Timers.Timer buildTimer;
        private Stopwatch stopwatch;

        public MainForm()
        {
            InitializeComponent();
            settings = UserSettings.Instance;
            this.Load += MainForm_Load;

            this.Icon = new Icon(AppDomain.CurrentDomain.BaseDirectory + "svincoolvalmetlogga.ico");
            this.Text = "Training Manager Builder";
            btnRebuildAndPackage.Enabled = false;

            progressSteps = new Dictionary<string, ProgressStepManager>
            {
                { "UpdateFileVersions", new ProgressStepManager(lblUpdateFileVersions, progressBarUpdateFileVersions, lblElapsedTimeFileVersion, lblStatusFileVersion) },
                { "BuildTM", new ProgressStepManager(lblBuildTM, progressBarTM, lblElapsedTimeTM, lblStatusTM) },
                { "BuildWeb", new ProgressStepManager(lblBuildWeb, progressBarWeb, lblElapsedTimeWeb, lblStatusWeb) },
                { "copyZips", new ProgressStepManager(lblCopyZips, progressBarCopyZip, lblElapsedTimeCopyZips, lblStatusCopyZips) },
                { "BuildInstaller", new ProgressStepManager(lblBuildInstaller, progressBarInstaller, lblElapsedTimeInstaller, lblStatusInstaller) }
            };
            InitTimerAndStopwatch();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                RemovePlaceholderLabels();

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
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingSettings = false;
            }
        }

        private void InitTimerAndStopwatch()
        {
            stopwatch = new Stopwatch();
            buildTimer = new Timer(1000);
            buildTimer.Elapsed += OnTimedEvent;
        }
        private int dotCount = 0;
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            dotCount = (dotCount % 3) + 1;
            string dots = new string('.', dotCount);
            if (btnRebuildAndPackage.InvokeRequired)
            {
                btnRebuildAndPackage.Invoke(new Action(() =>
                {
                    btnRebuildAndPackage.Text = $"Building{dots}\nElapsed: {stopwatch.Elapsed:mm\\:ss}";
                }));
            }
            else
            {
                btnRebuildAndPackage.Text = $"Building{dots}\nElapsed: {stopwatch.Elapsed:mm\\:ss}";
            }
        }


        private void RemovePlaceholderLabels()
        {
            lblStatusFileVersion.Text = "";
            lblStatusTM.Text = "";
            lblStatusWeb.Text = "";
            lblStatusCopyZips.Text = "";
            lblStatusInstaller.Text = "";
        }

        private void LoadVersion()
        {
            versionManager = new VersionManager(txtSourcePath.Text);
            LoadCurrentVersion();

            btnRebuildAndPackage.Enabled = true;

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
                        btnRebuildAndPackage.Enabled = false;
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
            if (!Directory.Exists(folderPath)) return false;

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

        private async void btnRebuildAndPackage_Click(object sender, EventArgs e)
        {

            string oldVersion = $"{txtCurrentMajor.Text}.{txtCurrentMinor.Text}.{txtCurrentBuild.Text}.{txtCurrentRevision.Text}";
            string newVersion = $"{txtNextMajor.Text}.{txtNextMinor.Text}.{txtNextBuild.Text}.{txtNextRevision.Text}";

            try
            {
                StartBuildTimer();
                BuildManager buildManager = new BuildManager(txtSourcePath.Text, progressSteps, txtOutputPath.Text,
                    newVersion, oldVersion);


                // BuildAsync and package the project
                bool buildSuccess = await buildManager.BuildAndPackage();
                StopBuildTimer();
                if (!buildSuccess)
                {
                    Logger.LogError("Build and package failed for whole project.");
                    throw new Exception("Build and package failed for whole project.");
                }


                Logger.Log($"BuildAsync and package completed in {stopwatch.Elapsed.TotalSeconds} seconds.");

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

        private void StartBuildTimer()
        {
            LockControls();
            stopwatch.Restart();
            buildTimer.Start();
        }

        private void StopBuildTimer()
        {
            stopwatch.Stop();
            buildTimer.Stop();
            if (btnRebuildAndPackage.InvokeRequired)
            {
                btnRebuildAndPackage.Invoke(new Action(() =>
                {
                    btnRebuildAndPackage.Text = $"Building Done\nTotal time: {stopwatch.Elapsed:mm\\:ss}";
                }));
            }
            else
            {
                btnRebuildAndPackage.Text = $"Building Done\nTotal time: {stopwatch.Elapsed:mm\\:ss}";
            }
        }

        private void SetControlState(bool isEnabled)
        {
            var controls = new List<Control>
            {
                btnRebuildAndPackage, btnBrowseSource, btnBrowseOutput, txtSourcePath, txtOutputPath,
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            buildTimer?.Stop();
            buildTimer?.Dispose();
            stopwatch?.Stop();
            base.OnFormClosing(e);
        }
    }
}
