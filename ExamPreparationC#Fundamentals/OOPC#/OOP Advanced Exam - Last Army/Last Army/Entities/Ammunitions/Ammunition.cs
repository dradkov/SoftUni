public abstract class Ammunition : IAmmunition
{
    private const double DefaultWearLevelMultiplier = 100.0;

    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = this.Weight * DefaultWearLevelMultiplier;
    }

    public string Name { get; private set; }
    public double Weight { get; private set; }
    public double WearLevel { get; private set; }
    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}