namespace Minedraft.Models.Harvesters
{

    using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
    : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *= 3;
        this.EnergyRequirement *= 2;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Hammer Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.Append($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString();
    }
}

}
