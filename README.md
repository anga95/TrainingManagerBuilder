# Training Manager Builder

## Overview
Training Manager Builder is a utility application designed to streamline and automate the build and packaging process for Training Manager applications. It simplifies versioning, building, zipping, and version control integration.

## Features
- **Automated Version Management**: Automatically updates version files across multiple projects.
- **Build Automation**: Uses MSBuild to rebuild projects and package them into zip files.
- **Git Integration**: Optionally opens TortoiseGit for easy version control.
- **Customizable Output**: Allows users to define output directories for generated files.
- **Progress Tracking**: Provides progress bars and timers for build and packaging steps.

## Requirements for Running

This program is provided in a pre-built state, and you do not need to clone or build it from source.

### If Visual Studio is Already Installed
1. If you have Visual Studio installed on your machine, **no additional setup is required**.
2. Simply navigate to the folder containing the program and run the executable (`.exe`).
3. You will be able to use all features.

### Required Tools for Users Without Visual Studio
***Note:*** this part is not completely tested yet. If you encounter any issues and find a solution, please update this section.
To use this programs Build And Zip feature, ensure that you install the following components from `vs_BuildTools.exe`:
- **.NET desktop build tools**
- Ensure that **MSBuild** is selected during installation.
- You may also need **.NET Framework 4.7.2 or later** for the application to run properly.

## Usage
1. Start the application and select the source directory that contains the `.sln` solution file.
2. Optionally specify an output directory where the builds and packages will be saved. If no selection is done, it will be saved where TMBuilder is located.
3. Check the checkboxes you  want to be enabled.
4. Click "Build and Package" to initiate the process.
5. Once the build process is complete, if enabled, the output folder or TortoiseGit will automatically open.
