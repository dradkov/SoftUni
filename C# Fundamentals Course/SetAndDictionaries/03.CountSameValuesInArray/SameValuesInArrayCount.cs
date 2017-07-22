namespace CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SameValuesInArrayCount
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' ','\t','\n' },StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse);

            var dict = new SortedDictionary<double, int>();


            foreach (var num in numbers)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict[num] = 1;
                }

            }
            if (dict.Any())
            {
                foreach (var num in dict)
                {
                    Console.WriteLine($"{num.Key} - {num.Value} times");
                }
            }
            else
            {
                Console.WriteLine(0);
            }     

        }
    }
}
