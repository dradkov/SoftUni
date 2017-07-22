namespace SalesReport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SalesReport
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var dict = new SortedDictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                var currNum = Console.ReadLine().Split().ToArray();

                var town = currNum[0];               
                var price = decimal.Parse(currNum[2]);
                var qunt = decimal.Parse(currNum[3]);

                decimal result = price * qunt;

                if (!dict.ContainsKey(town))
                {
                    dict.Add(town, 0);
                }
                dict[town] += result;
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key:f2} -> {item.Value:f2}");
            }
        }
    }
}
