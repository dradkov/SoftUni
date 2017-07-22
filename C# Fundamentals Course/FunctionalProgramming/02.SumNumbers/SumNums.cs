namespace SumNumbers
{
    using System;
    using System.Linq;

    public class SumNums
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            var count = nums.Count();
            var result = nums.Sum();

            Console.WriteLine($"{count}\n{result}");

           
        }
    }
}
