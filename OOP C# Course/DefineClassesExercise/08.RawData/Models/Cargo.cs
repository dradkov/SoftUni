namespace RawData.Models
{
    public class Cargo
    {
        private double weight;
        private string type;


        public Cargo(double weight, string type)
        {
            this.Weight = weight;
            this.Type = type;

        }

        public double Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}


