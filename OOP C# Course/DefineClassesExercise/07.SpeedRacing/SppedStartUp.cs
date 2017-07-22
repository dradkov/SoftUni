namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SppedStartUp
    {
        static void Main(string[] args)
        {
            var numCars = int.Parse(Console.ReadLine());
            var listCars = new List<Car>();

            for (int i = 0; i < numCars; i++)
            {
                var split = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                var car = new Car(split[0], double.Parse(split[1]), double.Parse(split[2]));

                listCars.Add(car);
            }

            var info = Console.ReadLine();

            while (info != "End")
            {
                var split = info.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                var model = split[1];
                var distance = double.Parse(split[2]);

                listCars.Where(x => x.Model == model).ToList().ForEach(c => c.FindFuelExpence(distance));


                info = Console.ReadLine();
            }
            foreach (var car in listCars)
            {
                Console.WriteLine($"{car.Model} {car.Fuel:F2} {car.DistanceTraveled}");
            }
        }
    }
}

