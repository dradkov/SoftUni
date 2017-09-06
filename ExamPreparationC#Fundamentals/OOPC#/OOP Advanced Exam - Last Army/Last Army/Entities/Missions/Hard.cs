public class Hard : Mission
{
    private const double DefaultEnduranceRequired = 80;
    private const double DefaultWearLevelDecrement = 70;
    private const string DefaultName = "Disposal of terrorists";

    public Hard(double scoreToComplete) : base(scoreToComplete)
    {
        this.Name = DefaultName;
        this.EnduranceRequired = DefaultEnduranceRequired;
        this.WearLevelDecrement = DefaultWearLevelDecrement;
    }

    public override string Name { get; }
    public override double EnduranceRequired { get; }
    public override double WearLevelDecrement { get; }
}