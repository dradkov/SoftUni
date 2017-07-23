using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Car : Vehicle
{
    private const double fuelIncreasing = 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override void Drive(double distance)
    {
        var consumation = fuelIncreasing + this.FuelConsumption;
        var travelCost = consumation * distance;

        if (travelCost <= this.FuelQuantity)
        {
            this.FuelQuantity -= travelCost;
            Console.WriteLine($"{typeof(Car)} travelled {distance} km"); ;
        }
        else
        {
            Console.WriteLine($"{typeof(Car)} needs refueling"); 
        }

    }
 
    public override void AddFuel(double fuel)
    {
        if (fuel >= this.TankCapacity)
        {
            Console.WriteLine("Cannot fit fuel in tank");
        }
        else if (fuel<=0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else
        {
            this.FuelQuantity += fuel;
        }
    }

    public override string ToString()
    {
        return $"{typeof(Car)}: {this.FuelQuantity:F2}";
    }
}

