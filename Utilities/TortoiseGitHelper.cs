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

    public void OpenCommitDialog(string repositoryPath, string newVersion)
    {
        try
        {
            AddFilesToGit(repositoryPath, newVersion);

            string commitMessage = $"Release {newVersion}";

            // Open TortoiseGit commit dialog
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = tortoiseGitPath,
                Arguments = $"/command:commit /path:\"{repositoryPath}\" /logmsg:\"{commitMessage}\"",
                UseShellExecute = true
            };

            Process process = Process.Start(startInfo);
            if (process != null)
            {
                Logger.Log("TortoiseGit commit dialog opened successfully.");
            }
            else
            {
                Logger.LogError("Failed to start TortoiseGit process.");
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to open TortoiseGit: {ex.Message}");
            throw;
        }
    }

    private void AddFilesToGit(string repositoryPath, string newVersion)
    {
        List<string> filesToAdd = new List<string>
        {
            Path.Combine(repositoryPath, $"TMInstaller\\Files\\TM {newVersion}.zip"),
            Path.Combine(repositoryPath, $"TMInstaller\\Files\\TM Reports Website {newVersion}.zip")
        };

        Logger.LogNewSection("Starting to add files to Git...");

        foreach (var file in filesToAdd)
        {
            try
            {
                Logger.Log($"Attempting to add file to Git: {file}");

                ProcessStartInfo gitAddInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = $"add \"{file}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = repositoryPath
                };

                using (Process process = Process.Start(gitAddInfo))
                {
                    process.WaitForExit();
                    if (process.ExitCode == 0)
                    {
                        Logger.Log($"Successfully added file to Git: {file}");
                    }
                    else
                    {
                        string error = process.StandardError.ReadToEnd();
                        Logger.LogError($"Failed to add file {file} to Git: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception occurred while adding file {file} to Git: {ex.Message}");
            }
        }

        Logger.Log("Finished adding files to Git.");
    }

}