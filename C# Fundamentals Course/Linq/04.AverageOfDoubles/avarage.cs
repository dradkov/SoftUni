namespace AverageOfDoubles
{
    using System;
    using System.Linq;

    public class Avarage
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(double.Parse).Average();

            Console.WriteLine($"{nums:F2}");

        }
    }
}
