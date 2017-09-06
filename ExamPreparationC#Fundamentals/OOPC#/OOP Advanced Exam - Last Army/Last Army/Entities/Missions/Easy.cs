public class Easy : Mission
{
    private const double DefaultEnduranceRequired = 20;
    private const double DefaultWearLevelDecrement = 30;
    private const string DefaultName = "Suppression of civil rebellion";

    public Easy(double scoreToComplete) : base(scoreToComplete)
    {
        this.Name = DefaultName;
        this.EnduranceRequired = DefaultEnduranceRequired;
        this.WearLevelDecrement = DefaultWearLevelDecrement;
    }

    public override string Name { get; }
    public override double EnduranceRequired { get; }
    public override double WearLevelDecrement { get; }
}