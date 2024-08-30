using System.Text.RegularExpressions;

public class VersionManager
{
    private string versionPattern = @"\d+\.\d+\.\d+\.\d+";
    private List<string> filesToUpdate;

    public VersionManager(string sourcePath)
    {
        filesToUpdate = new List<string>
        {
            Path.Combine(sourcePath, @"BusinessLayer\Properties\AssemblyInfo.cs"),
            Path.Combine(sourcePath, @"TM\Properties\AssemblyInfo.cs"),
            Path.Combine(sourcePath, @"TM\TranslationKeys.xml"),
            Path.Combine(sourcePath, @"TMInstaller\Files\Settings.xml"),
            Path.Combine(sourcePath, @"TMInstaller\Properties\AssemblyInfo.cs"),
            Path.Combine(sourcePath, @"TMInstaller\TranslationKeys.xml"),
            Path.Combine(sourcePath, @"TMReportsWebsite\Version\Version.txt"),
            Path.Combine(sourcePath, @"TMService\Properties\AssemblyInfo.cs"),
            Path.Combine(sourcePath, @"TranslationFileConverter\Properties\AssemblyInfo.cs"),
            Path.Combine(sourcePath, @"UserInterface\Properties\AssemblyInfo.cs")
        };
    }

    public (int Major, int Minor, int Build, int Revision) GetCurrentVersion()
    {
        string content = File.ReadAllText(filesToUpdate[0]);
        Match match = Regex.Match(content, versionPattern);
        if (match.Success)
        {
            string version = match.Value;
            var versionParts = version.Split('.');
            int major = int.Parse(versionParts[0]);
            int minor = int.Parse(versionParts[1]);
            int build = int.Parse(versionParts[2]);
            int revision = int.Parse(versionParts[3]);
            return (major, minor, build, revision);
        }
        throw new InvalidOperationException("Version number not found in the specified files.");
    }

    public void UpdateVersionInFiles(string newVersion)
    {
        foreach (var file in filesToUpdate)
        {
            string content = File.ReadAllText(file);
            content = Regex.Replace(content, versionPattern, newVersion);
            File.WriteAllText(file, content);
        }
    }

    public (int Major, int Minor, int Build, int Revision) GetNextVersion(int currentMajor, int currentMinor, int currentBuild, int currentRevision)
    {
        int nextRevision = currentRevision + 1;
        return (currentMajor, currentMinor, currentBuild, nextRevision);
    }
}
