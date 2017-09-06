public class Gun : Ammunition
{
    private const double DefaultWeight = 1.4d;

    public Gun(string name) : base(name, DefaultWeight)
    {
    }
}
