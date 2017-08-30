namespace Minedraft.Models.Harvesters
{
    using System.Text;

    public class SonicHarvester : Harvester
    {

        public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
        {
            this.SonicFactor = sonicFactor;
            this.EnergyRequirement = this.EnergyRequirement / this.SonicFactor;
        }


        public int SonicFactor { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Sonic Harvester - {this.Id}");
            sb.AppendLine($"Ore Output: {this.OreOutput}");
            sb.Append($"Energy Requirement: {this.EnergyRequirement}");

            return sb.ToString();
        }
    }
}
