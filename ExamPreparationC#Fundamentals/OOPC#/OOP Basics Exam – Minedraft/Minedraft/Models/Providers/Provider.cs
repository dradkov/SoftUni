namespace Minedraft.Models.Providers
{

    using System;
    using Minedraft.Interfaces;

    public abstract class Provider : IProvider
    {

        private string id;
        private double energyOutput;


        public Provider(string id, double energyOutput)
        {
            this.Id = id;
            this.EnergyOutput = energyOutput;
        }



        public string Id
        {
            get => this.id;
            protected set => this.id = value;

        }

        public double EnergyOutput
        {
            get => this.energyOutput;

            protected set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
                }
                this.energyOutput = value;
            }
        }

    }
}
