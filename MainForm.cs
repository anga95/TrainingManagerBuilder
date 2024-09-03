using System.Diagnostics;
using TrainingManagerBuilder.Builders;
using TrainingManagerBuilder.Utilities;

namespace TrainingManagerBuilder
{
    public partial class MainForm : Form
    {
        private VersionManager versionManager;
        private IBuilder tmBuilder, tmWebsiteBuilder, tmInstallerBuilder;
        private ZipUtilities zipUtilities;
        private ProcessTimerManager processTimerManager;
        private UserSettings userSettings;

        public MainForm()
        {
            InitializeComponent();
            this.Icon = new Icon(AppDomain.CurrentDomain.BaseDirectory + "svincoolvalmetlogga.ico");
            this.Text = "Training Manager Builder";
            btnBuildAndPackage.Enabled = false;
            processTimerManager = new ProcessTimerManager(new Dictionary<ProgressBar, Label>
            {
                { progressBarUpdateFileVersions, lblElapsedTimeFileVersion },
                { progressBarTM, lblElapsedTimeTM },
                { progressBarWeb, lblElapsedTimeWeb },
                { progressBarMove, lblElapsedTimeMove },
                { progressBarInstaller, lblElapsedTimeInstaller }
            });

            zipUtilities = new ZipUtilities();
            LoadUserSettings();
        }

        private void LoadUserSettings()
        {
            userSettings = UserSettings.LoadSettings();
            chkOpenGitAfterBuild.Checked = userSettings.OpenTortoiseGitAfterBuild;
            chkOpenOutputFolderAfterBuild.Checked = userSettings.OpenOutputDirectoryAfterBuild;
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                //folderBrowserDialog.Description = "Select the /source/-folder that contains the .sln file";
                folderBrowserDialog.ShowNewFolderButton = false;

                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    txtSourcePath.Text = folderBrowserDialog.SelectedPath;

                    // Validate the selected folder
                    if (IsValidSourcePath(txtSourcePath.Text))
                    {
                        versionManager = new VersionManager(txtSourcePath.Text);
#if DEBUG
                        txtOutputPath.Text = @"C:\Users\andgab\Downloads";
#endif
                        LoadCurrentVersion();
                        InitBuilders();

                        btnBuildAndPackage.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("The selected folder does not contain a valid solution file (.sln).\nPlease select a correct folder.",
                            "Invalid Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnBuildAndPackage.Enabled = false;
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

        private void InitBuilders()
        {
            string solutionPath = Path.Combine(txtSourcePath.Text, "TrainingManager.sln");

            tmBuilder = new BuildTM(solutionPath);
            tmWebsiteBuilder = new BuildWebsite(solutionPath);
            tmInstallerBuilder = new BuildTMInstaller(solutionPath);
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

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the folder where the output will be saved";
                folderBrowserDialog.ShowNewFolderButton = true;

                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    txtOutputPath.Text = folderBrowserDialog.SelectedPath;
                }
            }

        }
        private void UpdateVersionInFiles()
        {
            try
            {
                string newVersion = $"{txtNextMajor.Text}.{txtNextMinor.Text}.{txtNextBuild.Text}.{txtNextRevision.Text}";
                versionManager.UpdateVersionInFiles(newVersion, progressBarUpdateFileVersions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnBuildAndPackage_Click(object sender, EventArgs e)
        {
            Stopwatch totalStopwatch = new Stopwatch();
            totalStopwatch.Start();
            LockControls();
            string oldVersion = $"{txtCurrentMajor.Text}.{txtCurrentMinor.Text}.{txtCurrentBuild.Text}.{txtCurrentRevision.Text}";
            string newVersion = $"{txtNextMajor.Text}.{txtNextMinor.Text}.{txtNextBuild.Text}.{txtNextRevision.Text}";
            try
            {

                KillAllMSBuildProcesses();
                SetProgressBars();

                processTimerManager.StartTimer(progressBarUpdateFileVersions);
                UpdateVersionInFiles();
                processTimerManager.StopTimer(progressBarUpdateFileVersions);


                string outputDirectory = txtOutputPath.Text;
                string versionOutputDirectory = Path.Combine(outputDirectory, $"{newVersion}");
                if (!Directory.Exists(versionOutputDirectory))
                {
                    Directory.CreateDirectory(versionOutputDirectory);
                }


                // Step 2: Build and zip TM sequentially
                CheckAndWaitForOtherProcesses();
                string tmReleasePath = Path.Combine(txtSourcePath.Text, @"bin\Release");
                processTimerManager.StartTimer(progressBarTM);
                string tmZipPath = await Task.Run(() =>
                    BuildAndZipProject(tmBuilder, tmReleasePath, versionOutputDirectory, $"TM {newVersion}.zip", progressBarTM));
                processTimerManager.StopTimer(progressBarTM);


                // Step 3: Build and zip TM Reports Website sequentially
                CheckAndWaitForOtherProcesses();
                string websiteReleasePath = Path.Combine(txtSourcePath.Text, @"TMReportsWebsite");
                processTimerManager.StartTimer(progressBarWeb);
                string websiteZipPath = await Task.Run(() =>
                    BuildAndZipProject(tmWebsiteBuilder, websiteReleasePath, versionOutputDirectory, $"TM Reports Website {newVersion}.zip", progressBarWeb));
                processTimerManager.StopTimer(progressBarWeb);


                // Step 4: Replace zip files in TMInstaller
                processTimerManager.StartTimer(progressBarMove);
                await ReplaceInstallerZipfiles(tmZipPath, oldVersion, newVersion, websiteZipPath);
                processTimerManager.StopTimer(progressBarMove);


                // Step 5: Build and zip TM Installer
                CheckAndWaitForOtherProcesses();
                string installerReleasePath = Path.Combine(txtSourcePath.Text, @"TMInstaller\bin\Release");
                processTimerManager.StartTimer(progressBarInstaller);
                await Task.Run(() =>
                    BuildAndZipProject(tmInstallerBuilder, installerReleasePath, versionOutputDirectory, $"TM Installer {newVersion}.zip", progressBarInstaller));
                processTimerManager.StopTimer(progressBarInstaller);

                // step 6: Add Training Manager Release Notes.txt
                if (!File.Exists(Path.Combine(versionOutputDirectory, "Training Manager Release Notes.txt")))
                {
                    string releaseNotesPath = Path.Combine(versionOutputDirectory, "Training Manager Release Notes.txt");
                    File.Copy(Path.Combine(txtSourcePath.Text, "TMInstaller", "Documents", "Training Manager Release Notes.txt"), releaseNotesPath);
                }

                totalStopwatch.Stop();

                // Log success and total time
                Logger.Log($"Build, package, and installer update completed successfully.\n" +
                           $"Total time for BuildAndPackage process: {totalStopwatch.Elapsed.TotalMinutes:F2} minutes.");
            }
            catch (Exception ex)
            {
                totalStopwatch.Stop();
                Logger.LogError($"Build, package, and installer update failed after {totalStopwatch.Elapsed.TotalMinutes:F2} minutes. Error: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                totalStopwatch.Stop();
                UnlockControls();

                if (chkOpenGitAfterBuild.Checked)
                {
                    TortoiseGitHelper gitHelper = new TortoiseGitHelper();
                    string repositoryPath = txtSourcePath.Text;
                    gitHelper.OpenCommitDialog(repositoryPath, newVersion);
                }

                if (chkOpenOutputFolderAfterBuild.Checked)
                {
                    try
                    {
                        OpenOutputFolder(txtOutputPath.Text);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Failed to open output folder: {ex.Message}");
                    }
                }
            }
        }

        private void LockControls()
        {
            btnBuildAndPackage.Enabled = false;
            btnBrowseSource.Enabled = false;
            btnBrowseOutput.Enabled = false;
            txtSourcePath.Enabled = false;
            txtOutputPath.Enabled = false;
            txtCurrentMajor.Enabled = false;
            txtCurrentMinor.Enabled = false;
            txtCurrentBuild.Enabled = false;
            txtCurrentRevision.Enabled = false;
            txtNextMajor.Enabled = false;
            txtNextMinor.Enabled = false;
            txtNextBuild.Enabled = false;
            txtNextRevision.Enabled = false;
            //chkOpenGitAfterBuild.Enabled = false;
            //chkOpenOutputFolderAfterBuild.Enabled = false;
        }

        private void UnlockControls()
        {
            btnBuildAndPackage.Enabled = true;
            btnBrowseSource.Enabled = true;
            btnBrowseOutput.Enabled = true;
            txtSourcePath.Enabled = true;
            txtOutputPath.Enabled = true;
            txtCurrentMajor.Enabled = true;
            txtCurrentMinor.Enabled = true;
            txtCurrentBuild.Enabled = true;
            txtCurrentRevision.Enabled = true;
            txtNextMajor.Enabled = true;
            txtNextMinor.Enabled = true;
            txtNextBuild.Enabled = true;
            txtNextRevision.Enabled = true;
            //chkOpenGitAfterBuild.Enabled = true;
            //chkOpenOutputFolderAfterBuild.Enabled = true;
        }

        private void SetProgressBars()
        {
            progressBarTM.Value = 0;
            progressBarTM.Maximum = 2;
            progressBarWeb.Value = 0;
            progressBarWeb.Maximum = 2;
            progressBarMove.Value = 0;
            progressBarMove.Maximum = 2;
            progressBarInstaller.Value = 0;
            progressBarInstaller.Maximum = 2;
        }

        private async Task ReplaceInstallerZipfiles(string tmZipPath, string oldVersion, string newVersion, string websiteZipPath)
        {
            string installerPath = Path.Combine(txtSourcePath.Text, @"TMInstaller");
            await Task.Run(() => zipUtilities.ReplaceZipFile(installerPath, tmZipPath, oldVersion, newVersion, $"TM"));
            SetProgressBarValue(progressBarMove, 1);
            await Task.Run(() => zipUtilities.ReplaceZipFile(installerPath, websiteZipPath, oldVersion, newVersion, $"TM Reports Website"));
            SetProgressBarValue(progressBarMove, 2);
        }

        private void CheckAndWaitForOtherProcesses()
        {
            var runningProcesses = Process.GetProcessesByName("MSBuild");
            if (runningProcesses.Length > 0)
            {
                Logger.Log("Another MSBuild process is running. Waiting for it to finish...");

                foreach (var process in runningProcesses)
                {
                    process.WaitForExit();
                }

                Logger.Log("MSBuild process finished. Continuing...");
            }
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
        private void SetProgressBarValue(ProgressBar progressBar, int value)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() => progressBar.Value = value));
            }
            else
            {
                progressBar.Value = value;
            }
        }
        private void KillAllMSBuildProcesses()
        {
            var runningProcesses = Process.GetProcessesByName("MSBuild");
            if (runningProcesses.Length > 0)
            {
                Logger.Log("Killing all running MSBuild processes...");

                foreach (var process in runningProcesses)
                {
                    try
                    {
                        process.Kill();
                        Logger.Log($"MSBuild process (PID: {process.Id}) terminated.");
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Failed to terminate MSBuild process (PID: {process.Id}): {ex.Message}");
                    }
                }

                Logger.Log("All MSBuild processes have been terminated.");
            }
            else
            {
                Logger.Log("No MSBuild processes were running.");
            }
        }

        private string BuildAndZipProject(IBuilder builder, string releasePath, string outputDirectory, string zipFileName, ProgressBar progressBar)
        {
            builder.Build();
            SetProgressBarValue(progressBar, 1);

            string zipPath = Path.Combine(outputDirectory, zipFileName);
            zipUtilities.ZipDirectory(releasePath, zipPath);
            SetProgressBarValue(progressBar, 2);

            return zipPath;
        }

        private void chkOpenGitAfterBuild_CheckedChanged(object sender, EventArgs e)
        {
            userSettings.OpenTortoiseGitAfterBuild = chkOpenGitAfterBuild.Checked;
            userSettings.SaveSettings();

        }

        private void chkOpenOutputFolderAfterBuild_CheckedChanged(object sender, EventArgs e)
        {
            userSettings.OpenOutputDirectoryAfterBuild = chkOpenOutputFolderAfterBuild.Checked;
            userSettings.SaveSettings();
        }
    }
}
