namespace BoundedNumbers
{
    using System;
    using System.Linq;

    public class Bounded
    {
        static void Main()
        {
            var bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => bounds.Min() <= n && n <= bounds.Max())
                .ToList();

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
