namespace ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExcludeReverse
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var divisableNum = long.Parse(Console.ReadLine());


            Predicate<long> divisable = x => { return x % divisableNum == 0; };

            var result = new List<long>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!divisable(numbers[i]))
                {
                    result.Add(numbers[i]);
                }
            }

            result.Reverse();
            Console.WriteLine(string.Join(" ", result));


        }
    }
}
