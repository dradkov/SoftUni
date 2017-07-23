namespace FerrariTask
{
    using System;

    public class Ferrari : ICar
    {


        public Ferrari(string driver, string model)
        {
            this.Driver = driver;
            this.Model = model;
        }


        public string Model { get; }

        public string Driver { get; }

        public string PushGas()
        {
            return "Zadu6avam sA!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }
    }
}
