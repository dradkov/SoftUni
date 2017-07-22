namespace Rounding
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine("{0} => {1}", input[i], Math.Round(input[i], MidpointRounding.AwayFromZero));
            }
        }
    }
}

