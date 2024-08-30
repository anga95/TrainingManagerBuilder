namespace TrainingManagerBuilder
{
    public partial class MainForm : Form
    {
        private VersionManager versionManager;
        private IBuilder tmBuilder;
        private IBuilder tmWebsiteBuilder;
        private IBuilder tmInstallerBuilder;
        private ZipUtilities zipUtilities;

        public MainForm()
        {
            InitializeComponent();
            zipUtilities = new ZipUtilities();
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
                    LoadCurrentVersion();
                    InitBuilders();
                }
            }
        }

        private void InitBuilders()
        {
            //string tmPath = Path.Combine(txtSourcePath.Text, @"TM");
            //string websitePath = Path.Combine(txtSourcePath.Text, @"TMReportsWebsite");
            //string installerPath = Path.Combine(txtSourcePath.Text, @"TMInstaller");
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

        private void btnUpdateVersion_Click(object sender, EventArgs e)
        {
            try
            {
                string newVersion = $"{txtNextMajor.Text}.{txtNextMinor.Text}.{txtNextBuild.Text}.{txtNextRevision.Text}";
                versionManager.UpdateVersionInFiles(newVersion);
                MessageBox.Show("Version numbers updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnBuildAndPackage_Click(object sender, EventArgs e)
        {
            try
            {
                string oldVersion = $"{txtCurrentMajor.Text}.{txtCurrentMinor.Text}.{txtCurrentBuild.Text}.{txtCurrentRevision.Text}";
                string newVersion = $"{txtNextMajor.Text}.{txtNextMinor.Text}.{txtNextBuild.Text}.{txtNextRevision.Text}";


                string outputDirectory = txtOutputPath.Text;
                string versionOutputDirectory = Path.Combine(outputDirectory, $"TM {newVersion}");
                if (!Directory.Exists(versionOutputDirectory))
                {
                    Directory.CreateDirectory(versionOutputDirectory);
                }

                string tmZipPath = BuildAndZipTm(newVersion, versionOutputDirectory);
                string websiteZipPath = BuildAndZipWebsite(newVersion, versionOutputDirectory);

                string installerPath = Path.Combine(txtSourcePath.Text, @"TMInstaller");

                zipUtilities.ReplaceZipFile(installerPath, tmZipPath, oldVersion, newVersion, $"TM {oldVersion}.zip");
                zipUtilities.ReplaceZipFile(installerPath, websiteZipPath, oldVersion, newVersion, $"TM Reports Website {oldVersion}.zip");
                BuildAndZipInstaller(newVersion, versionOutputDirectory);

                MessageBox.Show("Build, package, and installer update completed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string BuildAndZipTm(string version, string versionOutputDirectory)
        {
            tmBuilder.Build();

            string tmReleasePath = Path.Combine(txtSourcePath.Text, @"bin\Release");
            string tmZipPath = Path.Combine(versionOutputDirectory, $"TM {version}.zip");
            zipUtilities.ZipDirectory(tmReleasePath, tmZipPath);

            return tmZipPath;
        }

        private string BuildAndZipWebsite(string version, string versionOutputDirectory)
        {
            tmWebsiteBuilder.Build();

            string websiteReleasePath = Path.Combine(txtSourcePath.Text, @"TMReportsWebsite");
            string websiteZipPath = Path.Combine(versionOutputDirectory, $"TM Reports Website {version}.zip");
            zipUtilities.ZipDirectory(websiteReleasePath, websiteZipPath);

            return websiteZipPath;
        }

        private void BuildAndZipInstaller(string version, string versionOutputDirectory)
        {

            tmInstallerBuilder.Build();

            string installerReleasePath = Path.Combine(txtSourcePath.Text, @"TMInstaller\bin\Release");
            string installerZipPath = Path.Combine(versionOutputDirectory, $"TM Installer {version}.zip");
            zipUtilities.ZipDirectory(installerReleasePath, installerZipPath);
        }


    }
}
