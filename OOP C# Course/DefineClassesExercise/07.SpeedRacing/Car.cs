namespace SpeedRacing
{
    using System;

   public class Car
    {
        private string model;
        private double fuel;
        private double fuelPerKm;
        private double distanceTraveled;


        public Car(string model, double fuel, double fuelPerKm)
        {
            this.Model = model;
            this.Fuel = fuel;
            this.FuelPerKm = fuelPerKm;

        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public double Fuel
        {
            get { return this.fuel; }
            set { this.fuel = value; }
        }
        public double FuelPerKm
        {
            get { return this.fuelPerKm; }
            set { this.fuelPerKm = value; }
        }

        public double DistanceTraveled
        {
            get { return this.distanceTraveled; }
            set { this.distanceTraveled = value; }
        }

        public void FindFuelExpence(double distance)
        {
            if (this.Fuel < (distance * this.FuelPerKm))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.Fuel -= distance * this.FuelPerKm;
                this.distanceTraveled += distance;
            }
        }
    }
}

