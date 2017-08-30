


using Minedraft.Factories;
using Minedraft.Models.Harvesters;
using Minedraft.Models.Providers;

namespace Minedraft.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class DraftManager
    {
        private string currentMode;
        private double totalStoredEnergy;
        private double totalMinedOre;
        private HarvesterFactory harvesterFactory;
        private ProviderFactory providerFactory;
        private List<Harvester> harvesters;
        private List<Provider> providers;

        public DraftManager()
        {
            this.currentMode = "Full";
            this.harvesters = new List<Harvester>();
            this.providers = new List<Provider>();
            this.harvesterFactory = new HarvesterFactory();
            this.providerFactory = new ProviderFactory();
        }

        public string RegisterHarvester(List<string> arguments)
        {
            try
            {
                this.harvesters.Add(this.harvesterFactory.Get(arguments));
            }
            catch (ArgumentException ae)
            {
                return ae.Message;
            }

            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }

        public string RegisterProvider(List<string> arguments)
        {
            try
            {
                this.providers.Add(this.providerFactory.Get(arguments));
            }
            catch (ArgumentException ae)
            {
                return ae.Message;
            }

            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }

        public string Day()
        {
            StringBuilder sb = new StringBuilder();

            double totalEnergyReqierment = harvesters.Sum(x => x.EnergyRequirement);
            double sumOreOutput = harvesters.Sum(c => c.OreOutput);
            if (currentMode == "Full")
            {
                totalEnergyReqierment = harvesters.Sum(x => x.EnergyRequirement);
                sumOreOutput = harvesters.Sum(c => c.OreOutput);
            }
            else if (currentMode == "Energy")
            {
                totalEnergyReqierment = 0;
                sumOreOutput = 0;

            }
            else if (currentMode == "Half")
            {
                totalEnergyReqierment = (60 * totalEnergyReqierment) / 100;
                sumOreOutput /= 2;
            }

            double sumEnergyOutput = providers.Sum(x => x.EnergyOutput);

            this.totalStoredEnergy += sumEnergyOutput;

            if (totalEnergyReqierment > this.totalStoredEnergy)
            {

                sb.AppendLine("A day has passed.");
                sb.AppendLine($"Energy Provided: {sumEnergyOutput}");
                sb.AppendLine($"Plumbus Ore Mined: {0}");
                this.totalMinedOre += 0;

            }
            else
            {
                this.totalStoredEnergy -= totalEnergyReqierment;

                sb.AppendLine("A day has passed.");
                sb.AppendLine($"Energy Provided: {sumEnergyOutput}");
                sb.AppendLine($"Plumbus Ore Mined: {sumOreOutput}");
                this.totalMinedOre += sumOreOutput;

            }


            return sb.ToString().Trim();
        }

        public string Mode(List<string> arguments)
        {
            string mode = arguments[0];
            this.currentMode = mode;

            return $"Successfully changed working mode to {mode} Mode";
        }

        public string Check(List<string> arguments)
        {
            string id = arguments[0];

            if (this.harvesters.Any(h => h.Id == id))
            {
                return this.harvesters.First(h => h.Id == id).ToString();
            }

            if (this.providers.Any(p => p.Id == id))
            {
                return this.providers.First(p => p.Id == id).ToString();
            }

            return $"No element found with id - {id}";
        }

        public string ShutDown()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"System Shutdown");
            sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
            sb.Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

            return sb.ToString();
        }
    }
}