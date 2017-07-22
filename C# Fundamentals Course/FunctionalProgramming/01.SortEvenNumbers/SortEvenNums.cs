namespace SortEvenNumbers
{
    using System;
    using System.Linq;

    public class SortEvenNums
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            var result = nums.Where(x => x % 2 == 0).OrderBy(x => x).ToArray();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
