namespace RawData.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RawDataStartUp
    {
        static void Main(string[] args)
        {
            var nunCommands = int.Parse(Console.ReadLine());

            var listCars = new List<Car>();

            for (int i = 0; i < nunCommands; i++)
            {
                var splitInfo = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                var model = splitInfo[0];
                var speed = int.Parse(splitInfo[1]);
                var power = double.Parse(splitInfo[2]);
                var weight = double.Parse(splitInfo[3]);
                var type = splitInfo[4];
                var tire1Pres = double.Parse(splitInfo[5]);
                var tyre1Age = int.Parse(splitInfo[6]);
                var tire2Pres = double.Parse(splitInfo[7]);
                var tyre2Age = int.Parse(splitInfo[8]);
                var tire3Pres = double.Parse(splitInfo[9]);
                var tyre3Age = int.Parse(splitInfo[10]);
                var tire4Pres = double.Parse(splitInfo[11]);
                var tyre4Age = int.Parse(splitInfo[12]);

                var car = new Car(model, new Engine(speed, power),
                    new Cargo(weight, type),
                    new List<Tyres>
                    {
                    new Tyres(tire1Pres, tyre1Age),
                    new Tyres(tire2Pres,tyre2Age),
                    new Tyres(tire3Pres, tyre3Age),
                    new Tyres(tire4Pres,tyre4Age)

                    });

                listCars.Add(car);

            }
            var command = Console.ReadLine();

            if (command == "fragile")
            {
                listCars
                    .Where(x => x.Cargo.Type == "fragile")
                    .Where(c => c.Tyres.Any(x => x.Presure < 1))
                    .Select(p => p.Model)
                    .ToList()
                    .ForEach(c => Console.WriteLine(c));

            }
            else
            {
                listCars
                      .Where(x => x.Cargo.Type == "flamable")
                      .Where(p => p.Engine.Power > 250)
                      .Select(p => p.Model)
                      .ToList()
                      .ForEach(c => Console.WriteLine(c));

            }
        }
    }
}
