namespace Avatar.Interfaces
{
    public interface IBender
    {
        string Name { get; }

        int Power { get; }

        double GetBenderTotalPower();
    }
}
