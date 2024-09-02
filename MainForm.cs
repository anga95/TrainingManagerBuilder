using System.Diagnostics;


// TODO TM INSTALLER KOPIERAR INTE RÄTT FILER TILL OUTPUT
namespace TrainingManagerBuilder
{
    public partial class MainForm : Form
    {
        private VersionManager versionManager;
        private IBuilder tmBuilder;
        private IBuilder tmWebsiteBuilder;
        private IBuilder tmInstallerBuilder;
        private ZipUtilities zipUtilities;

        private Stopwatch elapsedTimeStopWatch;
        private System.Windows.Forms.Timer elapsedTimeTimer;

        public MainForm()
        {
            InitializeComponent();
            zipUtilities = new ZipUtilities();

            elapsedTimeStopWatch = new Stopwatch();
            elapsedTimeTimer = new System.Windows.Forms.Timer();
            elapsedTimeTimer.Interval = 1000;
            elapsedTimeTimer.Tick += ElapsedTime_Tick;
        }

        private void ElapsedTime_Tick(object sender, EventArgs e)
        {
            lblElapsedTime.Text = elapsedTimeStopWatch.Elapsed.ToString(@"hh\:mm\:ss");
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the folder that contains the .sln file";
                folderBrowserDialog.ShowNewFolderButton = false;

                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    txtSourcePath.Text = folderBrowserDialog.SelectedPath;
                    versionManager = new VersionManager(txtSourcePath.Text);
                    txtOutputPath.Text = @"C:\Users\andgab\Downloads";
                    LoadCurrentVersion();
                    InitBuilders();
                }
            }
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
            KillAllMSBuildProcesses();
            SetProgressBars();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            elapsedTimeStopWatch.Start();
            elapsedTimeTimer.Start();

            Logger.Log("Build and package process started.");

            // Step 1: Update version in files
            UpdateVersionInFiles();

            try
            {
                string oldVersion = $"{txtCurrentMajor.Text}.{txtCurrentMinor.Text}.{txtCurrentBuild.Text}.{txtCurrentRevision.Text}";
                string newVersion = $"{txtNextMajor.Text}.{txtNextMinor.Text}.{txtNextBuild.Text}.{txtNextRevision.Text}";

                string outputDirectory = txtOutputPath.Text;
                string versionOutputDirectory = Path.Combine(outputDirectory, $"{newVersion}");
                if (!Directory.Exists(versionOutputDirectory))
                {
                    Directory.CreateDirectory(versionOutputDirectory);
                }

                CheckAndWaitForOtherProcesses();

                // Step 2: Build and zip TM sequentially
                string tmReleasePath = Path.Combine(txtSourcePath.Text, @"bin\Release");
                string tmZipPath = await Task.Run(() =>
                    BuildAndZipProject(tmBuilder, tmReleasePath, versionOutputDirectory, $"TM {newVersion}.zip", progressBarTM));
                CheckAndWaitForOtherProcesses();

                // Step 3: Build and zip TM Reports Website sequentially
                string websiteReleasePath = Path.Combine(txtSourcePath.Text, @"TMReportsWebsite");
                string websiteZipPath = await Task.Run(() =>
                    BuildAndZipProject(tmWebsiteBuilder, websiteReleasePath, versionOutputDirectory, $"TM Reports Website {newVersion}.zip", progressBarWeb));

                CheckAndWaitForOtherProcesses();

                // Step 4: Replace zip files in TMInstaller
                await ReplaceInstallerZipfiles(tmZipPath, oldVersion, newVersion, websiteZipPath);

                // Step 5: Build and zip TM Installer
                string installerReleasePath = Path.Combine(txtSourcePath.Text, @"TMInstaller\bin\Release");
                await Task.Run(() =>
                    BuildAndZipProject(tmInstallerBuilder, installerReleasePath, versionOutputDirectory, $"TM Installer {newVersion}.zip", progressBarInstaller));

                SetProgressBarValue(progressBarInstaller, 2);

                // step 6: Add Training Manager Release Notes.txt
                string releaseNotesPath = Path.Combine(versionOutputDirectory, "Training Manager Release Notes.txt");
                File.Copy(Path.Combine(txtSourcePath.Text, "TMInstaller", "Documents", "Training Manager Release Notes.txt"), releaseNotesPath);


                stopwatch.Stop();

                Logger.Log($"Build, package, and installer update completed successfully in {stopwatch.Elapsed.TotalMinutes:F2} minutes.");
                elapsedTimeStopWatch.Stop();
                elapsedTimeTimer.Stop();

                MessageBox.Show($"Build, package, and installer update completed successfully!\nTotal time {stopwatch.Elapsed.TotalMinutes:F2} minutes.");

                OpenOutputFolder(versionOutputDirectory);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                elapsedTimeStopWatch.Stop();
                elapsedTimeTimer.Stop();
                Logger.LogError($"Build, package, and installer update failed after {stopwatch.Elapsed.TotalMinutes:F2} minutes. Error: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

    }
}
