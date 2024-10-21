using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using TrainingManagerBuilder;


public class ZipUtilities
{
    public async Task<bool> ZipDirectoryAsync(Project project)
    {
        bool success = await Task.Run(() => ZipDirectory(project));
        return success;
    }

    public bool ZipDirectory(Project project)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Logger.LogNewSection($"Starting zipping of {project.BinReleasePath}");

        try
        {
            if (File.Exists(project.ZipFileInOutputDirectory.Path))
            {
                File.Delete(project.ZipFileInOutputDirectory.Path); // Deletes old zip file if it exists
                Logger.Log($"Deleted existing zip file: {project.ZipFileInOutputDirectory.Path}");
            }

            ZipFile.CreateFromDirectory(project.BinReleasePath, project.ZipFileInOutputDirectory.Path);
            Logger.Log($"Created zip file: {project.ZipFileInOutputDirectory.Path}");

            stopwatch.Stop();
            Logger.Log($"Zipping of {project.BinReleasePath} completed in {stopwatch.Elapsed.TotalSeconds} seconds.");
            return true;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error during zipping of {project.ZipFileInOutputDirectory.Path}: {ex.Message}");
            return false;
        }
    }
    public async Task<bool> ReplaceZipFileAsync(string installerPath, Project project)
    {
        bool success = await Task.Run(() => ReplaceZipFile(project));
        return success;
    }

    public bool ReplaceZipFile(Project project)
    {

        try
        {
            // Erase the old file if it exists
            if (File.Exists(project.OldZipFileInInstaller.Path))
            {
                File.Delete(project.OldZipFileInInstaller.Path);
                Logger.Log($"Deleted old file: {project.OldZipFileInInstaller.Path}");
            }

            // Erase the new file if it exists
            if (File.Exists(project.NewZipFileInInstaller.Path))
            {
                File.Delete(project.NewZipFileInInstaller.Path);
                Logger.Log($"Deleted existing new file: {project.NewZipFileInInstaller.Path}");
            }

            // Copy the new file to the installer path
            File.Copy(project.ZipFileInOutputDirectory.Path, project.NewZipFileInInstaller.Path);
            Logger.Log($"Copied new file: {project.ZipFileInOutputDirectory.Path} to {project.NewZipFileInInstaller.Path}");
            return true;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error replacing zip file {project.OldZipFileInInstaller.Name} with {project.NewZipFileInInstaller.Name}: {ex.Message}");
            return false;
        }
    }
}
