namespace GroupNumbers
{
    using System;
    using System.Linq;

    public class NumbersGroup
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            var dividedToZero = numbers.Where(z => Math.Abs(z) % 3 == 0).ToList();
            var dividedToOne = numbers.Where(z => Math.Abs(z) % 3 == 1).ToList();
            var dividedToTwo = numbers.Where(z => Math.Abs(z) % 3 == 2).ToList();

            Console.WriteLine(string.Join(" ",dividedToZero));
            Console.WriteLine(string.Join(" ",dividedToOne));
            Console.WriteLine(string.Join(" ",dividedToTwo));
        }
    }
}
