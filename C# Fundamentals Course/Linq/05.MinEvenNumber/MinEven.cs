namespace MinEvenNumber
{
    using System;
    using System.Linq;

    public class MinEven
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            try
            {
                decimal min = nums.Where(n => n % 2 == 0).Min();

                Console.WriteLine($"{min:F2}");
            }
            catch (Exception)
            {

                Console.WriteLine("No match");
                return;
            }

        }
    }
}
