namespace ArrangeIntegers
{
    using System.Linq;
    using System;

    public class StartUp
    {

        public static void Main(string[] args)
        {

            string[] intNums = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            string[] nums = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var res = nums.OrderBy(s => string.Join(null, s.Select(ch => intNums[ch - '0'])));

            Console.WriteLine(string.Join(", ", res));

        }

    }
}