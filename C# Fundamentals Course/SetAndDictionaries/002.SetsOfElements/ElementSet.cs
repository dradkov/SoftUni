namespace SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ElementSet
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                         .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse)
                         .ToArray();


            var n = numbers[0];
            var m = numbers[1];

            var setN = new SortedSet<int>();

            var setResult = new SortedSet<int>();
            

            for (int i = 0; i < n + m; i++)
            {
                var numInN = int.Parse(Console.ReadLine());

                if (!setN.Contains(numInN))
                {
                    setN.Add(numInN);
                }
                else
                {
                    setResult.Add(numInN);
                }

            }

            foreach (var item in setResult)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
