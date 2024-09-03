﻿namespace TrainingManagerBuilder.Builders;

public class BuildTMInstaller : Builder
{
    public BuildTMInstaller(string solutionPath) : base(solutionPath, "TMInstaller") { }

    public override void Build()
    {
        Clean();
        base.Build();
    }

    public override void Clean()
    {
        string projectDirectory = Path.Combine(Path.GetDirectoryName(solutionPath), "TMInstaller");
        string binPath = Path.Combine(projectDirectory, "bin");

        if (Directory.Exists(binPath))
        {
            Directory.Delete(binPath, true);
            Console.WriteLine("Deleted bin folder");
        }
    }
}