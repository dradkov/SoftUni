namespace Minedraft.Models.Providers
{

    using System.Text;

    public class PressureProvider : Provider
    {
        public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
        {
            this.EnergyOutput += (this.EnergyOutput / 2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pressure Provider - {this.Id}");
            sb.Append($"Energy Output: {this.EnergyOutput}");

            return sb.ToString();
        }
    }
}
