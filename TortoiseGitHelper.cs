using System.Diagnostics;

public class TortoiseGitHelper
{
    private readonly string tortoiseGitPath;

    public TortoiseGitHelper(string tortoiseGitExecutablePath = @"C:\Program Files\TortoiseGit\bin\TortoiseGitProc.exe")
    {
        if (File.Exists(tortoiseGitExecutablePath))
        {
            tortoiseGitPath = tortoiseGitExecutablePath;
        }
        else
        {
            throw new FileNotFoundException("TortoiseGit executable not found at the specified path.");
        }
    }

    public void OpenCommitDialog(string repositoryPath)
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = tortoiseGitPath,
                Arguments = $"/command:commit /path:\"{repositoryPath}\"",
                UseShellExecute = true
            };

            Process.Start(startInfo);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to open TortoiseGit: {ex.Message}");
            throw; // Optionally rethrow or handle the exception as needed
        }
    }
}