using System.Diagnostics;
using System.IO.Compression;

namespace TrainingManagerBuilder;

public class ZipUtilities
{
    public void ZipDirectory(string sourceDirectory, string zipFilePath)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Logger.LogNewSection($"Starting zipping of {sourceDirectory}");

        try
        {
            if (File.Exists(zipFilePath))
            {
                File.Delete(zipFilePath); // Deletes old zip file if it exists
                Logger.Log($"Deleted existing zip file: {zipFilePath}");
            }

            ZipFile.CreateFromDirectory(sourceDirectory, zipFilePath);
            Logger.Log($"Created zip file: {zipFilePath}");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error during zipping of {sourceDirectory}: {ex.Message}");
            throw;
        }
        finally
        {
            stopwatch.Stop();
            Logger.Log($"Zipping of {sourceDirectory} completed in {stopwatch.Elapsed.TotalSeconds} seconds.");
        }
    }

    public void ReplaceZipFile(string installerPath, string newZipFilePath, string oldVersion, string newVersion, string program)
    {
        string oldFileName = program + " " + oldVersion + ".zip";
        string oldFilePath = Path.Combine(installerPath, "Files", oldFileName);

        string newFileName = program + " " + newVersion + ".zip";
        string newFilePath = Path.Combine(installerPath, "Files", newFileName);

        try
        {
            // Ta bort den gamla filen om den finns
            if (File.Exists(oldFilePath))
            {
                File.Delete(oldFilePath);
                Logger.Log($"Deleted old file: {oldFilePath}");
            }

            // Ta bort den nya filen om den redan finns
            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
                Logger.Log($"Deleted existing new file: {newFilePath}");
            }

            // Kopiera den nya zip-filen till installer-mappen
            File.Copy(newZipFilePath, newFilePath);
            Logger.Log($"Copied new file: {newZipFilePath} to {newFilePath}");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error replacing zip file {oldFileName} with {newFileName}: {ex.Message}");
            throw;
        }
    }
}
