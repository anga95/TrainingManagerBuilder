using System;
using System.IO;
using TrainingManagerBuilder.Utilities;

namespace TrainingManagerBuilder
{
    public class Project
    {
        public string Name { get; }
        public string SourcePath { get; }
        public string BinReleasePath { get; }
        public string NewVersionNumber { get; }
        public string OldVersionNumber { get; }

        public string OutputDirectory { get; }
        public string ProjectDirectory { get; }
        public Builder Builder { get; }
        public ProjectType Type { get; }

        public ZipFileInfo ZipFileInOutputDirectory { get; }
        public ZipFileInfo OldZipFileInInstaller { get; }
        public ZipFileInfo NewZipFileInInstaller { get; }

        public string InstallerFilesDirectory { get; }


        public enum ProjectType
        {
            TM,
            Web,
            TMInstaller
        }

        public Project(ProjectType projectType, string sourcePath, string outputDirectory, string newVersionNumber, string oldVersionNumber)
        {

            // Validate parameters
            if (string.IsNullOrWhiteSpace(sourcePath))
                throw new ArgumentException("Source path cannot be null or empty.", nameof(sourcePath));

            if (string.IsNullOrWhiteSpace(outputDirectory))
                throw new ArgumentException("Output directory cannot be null or empty.", nameof(outputDirectory));

            if (string.IsNullOrWhiteSpace(newVersionNumber))
                throw new ArgumentException("New version number cannot be null or empty.", nameof(newVersionNumber));

            if (string.IsNullOrWhiteSpace(oldVersionNumber))
                throw new ArgumentException("Old version number cannot be null or empty.", nameof(oldVersionNumber));

            SourcePath = sourcePath;
            OutputDirectory = Path.Combine(outputDirectory, newVersionNumber);
            NewVersionNumber = newVersionNumber;
            OldVersionNumber = oldVersionNumber;
            InstallerFilesDirectory = Path.Combine(sourcePath, "TMInstaller", "Files");



            if (!Directory.Exists(OutputDirectory))
            {
                Directory.CreateDirectory(OutputDirectory);
            }

            switch (projectType)
            {
                case ProjectType.TM:
                    Name = "TM";
                    ProjectDirectory = Path.Combine(sourcePath, @"TM");
                    Builder = new Builder(sourcePath, Path.Combine(sourcePath, @"TM\TM.csproj"));
                    BinReleasePath = Path.Combine(sourcePath, @"bin\Release");
                    break;

                case ProjectType.Web:
                    Name = "TM Reports Website";
                    Builder = new Builder(sourcePath, Path.Combine(sourcePath, @"TMReportsWebsite\website.publishproj"));
                    ProjectDirectory = Path.Combine(sourcePath, @"TMReportsWebsite");
                    BinReleasePath = Path.Combine(sourcePath, @"TMReportsWebsite");
                    break;

                case ProjectType.TMInstaller:
                    Name = "TM Installer";
                    Builder = new Builder(sourcePath, Path.Combine(sourcePath, @"TMInstaller\TMInstaller.csproj"));
                    ProjectDirectory = Path.Combine(sourcePath, @"TMInstaller");
                    BinReleasePath = Path.Combine(sourcePath, @"TMInstaller\bin\Release");
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(projectType), $"Unknown project type: {projectType}");
            }


            //File names for the old zip in installer and the new zip that replaces it
            if (projectType == ProjectType.TM || projectType == ProjectType.Web)
            {
                string oldName = Name + " " + oldVersionNumber + ".zip";
                string newName = Name + " " + newVersionNumber + ".zip";

                OldZipFileInInstaller = new ZipFileInfo(oldName,
                    Path.Combine(InstallerFilesDirectory, oldName));
                NewZipFileInInstaller = new ZipFileInfo(newName,
                    Path.Combine(InstallerFilesDirectory, newName));
            }

            string ZipFileInOutputDirectoryName = $"{Name} {newVersionNumber}.zip";
            ZipFileInOutputDirectory = new ZipFileInfo(ZipFileInOutputDirectoryName,
                Path.Combine(OutputDirectory, ZipFileInOutputDirectoryName));
        }
    }
}
