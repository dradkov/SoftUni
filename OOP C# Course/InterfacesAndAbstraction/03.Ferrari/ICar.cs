namespace FerrariTask
{
    public interface ICar
    {
        string Model { get; }

        string Driver { get; }

        string UseBrakes();

        string PushGas();
    }
}
