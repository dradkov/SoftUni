namespace Avatar.Models.Benders
{
    public class EarthBender : Bender
    {
        private double groundSaturation;

        public EarthBender(string name, int power, double groundSaturation) : base(name, power)
        {
            this.GroundSaturation = groundSaturation;
        }

        public double GroundSaturation
        {
            get => this.groundSaturation;
            set => this.groundSaturation = value;
        }

        public override double GetBenderTotalPower()
        {
            return this.Power * this.GroundSaturation;
        }

        public override string ToString()
        {
            return $"###Earth Bender: {this.Name}, Power: {this.Power}, Ground Saturation: {this.GroundSaturation:F2}";
        }
    }
}
