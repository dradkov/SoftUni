using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CarSalesStartUp
{
    static void Main()
    {
        var numOfEngines = int.Parse(Console.ReadLine());

        var listEngines = new List<Engine>();
        var listCars = new List<Car>();

        for (int i = 0; i < numOfEngines; i++)
        {
            var splitEngineInfo = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            var engine = splitEngineInfo[0];
            var power = double.Parse(splitEngineInfo[1]);
            var diplacement = 0d;
            var efficiency = "n/a";

            if (splitEngineInfo.Length == 3)
            {
                var toChar = splitEngineInfo[2].ToCharArray();
                if (char.IsDigit(toChar[0]))
                {
                    diplacement = double.Parse(splitEngineInfo[2]);
                    //efficiency = "n/a";
                }
                else
                {
                    efficiency = splitEngineInfo[2];
                    //diplacement = "n/a";
                }
            }
            else if (splitEngineInfo.Length > 3)
            {

                diplacement = double.Parse(splitEngineInfo[2]);
                efficiency = splitEngineInfo[3];

            }


            listEngines.Add(new Engine(engine, power, diplacement, efficiency));

        }

        var numOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numOfCars; i++)
        {
            var splitCarInfo = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            var model = splitCarInfo[0];
            var engine = splitCarInfo[1];
            var weigth = 0d;
            var color = "n/a";

            if (splitCarInfo.Length == 3)
            {
                var toChar = splitCarInfo[2].ToCharArray();
                if (char.IsDigit(toChar[0]))
                {
                    weigth = double.Parse(splitCarInfo[2]);

                }
                else
                {
                    color = splitCarInfo[2];
                    //weigth = n/a;
                }
            }
            else if (splitCarInfo.Length > 3)
            {
                weigth = double.Parse(splitCarInfo[2]);
                color = splitCarInfo[3];
            }

            listCars.Add(new Car(model, engine, weigth, color));

        }

        var result = listCars.Join(listEngines, car => car.Engine, eng => eng.Engines, (car, eng) => new
        {
            Model = car.Model,
            Engines = eng.Engines,
            Power = eng.Power,
            Displacement = eng.Displacement,
            Efficiency = eng.Efficiency,
            Weigth = car.Weight,
            Color = car.Color
        }).ToList();



        foreach (var car in result)
        {
            if (car.Displacement == 0 )
            {
                if (car.Weigth ==0)
                {
                    Console.WriteLine($"{car.Model}:");
                    Console.WriteLine($" {car.Engines}:");
                    Console.WriteLine($"  Power: {car.Power}");
                    Console.WriteLine($"  Displacement: n/a");
                    Console.WriteLine($"  Efficiency: {car.Efficiency}");
                    Console.WriteLine($" Weight: n/a");
                    Console.WriteLine($" Color: {car.Color}");
                }
                else
                {
                    Console.WriteLine($"{car.Model}:");
                    Console.WriteLine($" {car.Engines}:");
                    Console.WriteLine($"  Power: {car.Power}");
                    Console.WriteLine($"  Displacement: n/a");
                    Console.WriteLine($"  Efficiency: {car.Efficiency}");
                    Console.WriteLine($" Weight: {car.Weigth}");
                    Console.WriteLine($" Color: {car.Color}");
                }
                
            }
            else if (car.Weigth == 0)
            {
                if (car.Displacement == 0)
                {
                    Console.WriteLine($"{car.Model}:");
                    Console.WriteLine($" {car.Engines}:");
                    Console.WriteLine($"  Power: {car.Power}");
                    Console.WriteLine($"  Displacement: n/a");
                    Console.WriteLine($"  Efficiency: {car.Efficiency}");
                    Console.WriteLine($" Weight: n/a");
                    Console.WriteLine($" Color: {car.Color}");
                }
                else
                {
                    Console.WriteLine($"{car.Model}:");
                    Console.WriteLine($" {car.Engines}:");
                    Console.WriteLine($"  Power: {car.Power}");
                    Console.WriteLine($"  Displacement: {car.Displacement}");
                    Console.WriteLine($"  Efficiency: {car.Efficiency}");
                    Console.WriteLine($" Weight: n/a");
                    Console.WriteLine($" Color: {car.Color}");
                }
            }
            else
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($" {car.Engines}:");
                Console.WriteLine($"  Power: {car.Power}");
                Console.WriteLine($"  Displacement: {car.Displacement}");
                Console.WriteLine($"  Efficiency: {car.Efficiency}");
                Console.WriteLine($" Weight: {car.Weigth}");
                Console.WriteLine($" Color: {car.Color}");
            }

            

        }

            
    }
}

