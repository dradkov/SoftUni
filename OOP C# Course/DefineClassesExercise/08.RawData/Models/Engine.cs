namespace RawData.Models
{
    public class Engine
    {
        private int speed;
        private double power;


        public Engine(int speed, double power)
        {
            this.Speed = speed;
            this.Power = power;

        }


        public int Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }
        public double Power
        {
            get { return this.power; }
            set { this.power = value; }
        }
    }
}
