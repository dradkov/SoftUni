namespace EnduranceRally
{
    using System;
    using System.Linq;

    class EnduranceRally
    {
        static void Main(string[] args)
        {
            var driversList = Console.ReadLine().Split().ToArray();
            var zones = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var checkpoints = Console.ReadLine().Split().Select(int.Parse).ToArray();


            foreach (var driver in driversList)
            {
                double fuel = driver.First();

                
                for (int i = 0; i < zones.Length; i++)
                {
                    var currentfuel = zones[i];
                    if (checkpoints.Contains(i))
                    {
                        fuel += currentfuel;
                    }
                    else
                    {
                        fuel -= currentfuel;
                    }
                    if (fuel<=0)
                    {
                        Console.WriteLine($"{driver} - reached {i}");
                        break;
                   }
                             
                }
                if (fuel > 0)
                {
                    Console.WriteLine($"{driver} - fuel left {fuel:f2}");
                }

            }
        }
    }
}
