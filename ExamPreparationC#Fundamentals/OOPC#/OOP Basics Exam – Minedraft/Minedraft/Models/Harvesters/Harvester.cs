namespace Minedraft.Models.Harvesters
{

    using System;
    using Minedraft.Interfaces;

    public abstract class Harvester : IHarvester
    {

        private string id;
        private double oreOutput;
        private double energyRequirement;

        protected Harvester(string id, double oreOutput, double energyRequirement)
        {
            this.Id = id;
            this.OreOutput = oreOutput;
            this.EnergyRequirement = energyRequirement;

        }


        public string Id
        {
            get => this.id;
            protected set => this.id = value;
        }

        public double OreOutput
        {
            get => this.oreOutput;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
                }
                this.oreOutput = value;
            }
        }

        public double EnergyRequirement
        {
            get => this.energyRequirement;
            protected set
            {
                if (value < 0 || value > 20000)
                {
                    throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
                }
                this.energyRequirement = value;
            }
        }

    }
}
