using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VehiclesStartUp
{
    public const double fuelIncreasing = 1.4;
    static void Main(string[] args)
    {
        var listVehicles = new List<Vehicle>();

        var carInfo = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
        listVehicles.Add(car);

        var truckInfo = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
        listVehicles.Add(truck);

        var busInfo = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        var bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
        listVehicles.Add(bus);


        var numCommands = int.Parse(Console.ReadLine());




        for (int i = 0; i < numCommands; i++)
        {
            var command = Console.ReadLine()
                .Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var move = command[0].Trim();
            var vehicle = command[1].Trim();
            var distance = double.Parse(command[2]);



            if (move == "Drive")
            {
                switch (vehicle)
                {
                    case "Car": car.Drive(distance); break;
                    case "Truck": truck.Drive(distance); break;
                     case "Bus":  bus.Drive(distance, fuelIncreasing); break;
                    default:
                        break;
                }
            }
            else if (move == "Refuel")
            {
                switch (vehicle)
                {
                    case "Car": car.AddFuel(distance); break;
                    case "Truck": truck.AddFuel(distance); break;
                    case "Bus": bus.AddFuel(distance); break;
                    default:
                        break;
                }
            }
            else if (move == "DriveEmpty")
            {
                 
                bus.Drive(distance);
            }

        }

        foreach (var vehicle in listVehicles)
        {
            Console.WriteLine(vehicle.ToString());           
        }
    }
}

