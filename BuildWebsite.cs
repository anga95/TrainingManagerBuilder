namespace TrainingManagerBuilder;

public class BuildWebsite : Builder
{
    public BuildWebsite(string solutionPath) : base(solutionPath, "TMReportsWebsite") { }

    public override void Clean() { }
}