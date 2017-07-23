using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Truck : Vehicle
{
    private const double fuelIncreasing = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override void AddFuel(double fuel)
    {
        fuel = (fuel * 95) / 100;

       if (fuel <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else
        {
            this.FuelQuantity += fuel;
        }
    }

    public override void Drive(double distance)
    {
        var consumation = this.FuelConsumption + fuelIncreasing;
        var travelCost = consumation * distance;

        if (travelCost<= this.FuelQuantity)
        {
            this.FuelQuantity -= travelCost;
            Console.WriteLine ($"{typeof(Truck)} travelled {distance} km"); 
        }
        else
        {
            Console.WriteLine($"{typeof(Truck)} needs refueling");
        }

       
    }

    public override string ToString()
    {
        return $"{typeof(Truck)}: {this.FuelQuantity:F2}";
    }
}
