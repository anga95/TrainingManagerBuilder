namespace TrainingManagerBuilder;

public class BuildTM : Builder
{
    public BuildTM(string solutionPath) : base(solutionPath, "TM") { }

    public override void Clean() { }
}