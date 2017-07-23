namespace FerrariTask
{
    using System;

    public class StartUpFerrari
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();

            ICar car = new Ferrari(name, "488-Spider");

            Console.WriteLine($"{car.Model}/{car.UseBrakes()}/{car.PushGas()}/{car.Driver}");

        }
    }
}

