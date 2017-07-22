namespace RawData.Models
{
    public class Tyres
    {
        private double presure;
        private int age;

        public Tyres(double presure, int age)
        {
            this.Presure = presure;
            this.Age = age;
        }

        public double Presure
        {
            get { return this.presure; }
            set { this.presure = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
    }
}

