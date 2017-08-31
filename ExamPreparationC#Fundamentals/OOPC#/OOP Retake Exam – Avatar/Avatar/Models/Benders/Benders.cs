namespace Avatar.Models
{
    using Avatar.Interfaces;

    public abstract class Bender : IBender
    {

        private string name;
        private int power;

        public Bender(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }


        public string Name
        {
            get => this.name;
            protected set => this.name = value;
        }

        public int Power
        {
            get => this.power;
            protected set => this.power = value;

        }

        public abstract double GetBenderTotalPower();

    }
}
