using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Bus : Vehicle

{
   
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override void AddFuel(double fuel)
    {
        if (fuel>=this.TankCapacity)
        {
            Console.WriteLine("Cannot fit fuel in tank");
        }
        else
        {
            this.FuelQuantity += fuel;
        }
       
    }

    public override void Drive(double distance)
    {
      
       
        var travelCost = this.FuelConsumption * distance;

        if (travelCost <= this.FuelQuantity)
        {
            this.FuelQuantity -= travelCost;
            Console.WriteLine($"{typeof(Bus)} travelled {distance} km"); ;
        }
        else
        {
            Console.WriteLine($"{typeof(Bus)} needs refueling");
        }
    }
    public void Drive(double distance, double fuelIncreasing)
    {
        var consumation = fuelIncreasing + this.FuelConsumption;
        var travelCost = consumation * distance;

        if (travelCost <= this.FuelQuantity)
        {
            this.FuelQuantity -= travelCost;
            Console.WriteLine($"{typeof(Bus)} travelled {distance} km"); ;
        }
        else
        {
            Console.WriteLine($"{typeof(Bus)} needs refueling");
        }
    }

    public override string ToString()
    {
        return $"{typeof(Bus)}: {this.FuelQuantity:F2}";
    }
}

