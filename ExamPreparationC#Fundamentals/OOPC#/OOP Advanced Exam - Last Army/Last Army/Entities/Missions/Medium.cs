public class Medium : Mission
{
    private const double DefaultEnduranceRequired = 50;
    private const double DefaultWearLevelDecrement = 50;
    private const string DefaultName = "Capturing dangerous criminals";

    public Medium(double scoreToComplete) : base(scoreToComplete)
    {
        this.Name = DefaultName;
        this.EnduranceRequired = DefaultEnduranceRequired;
        this.WearLevelDecrement = DefaultWearLevelDecrement;
    }

    public override string Name { get; }
    public override double EnduranceRequired { get; }
    public override double WearLevelDecrement { get; }
}