namespace CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class Comparator
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(long.Parse).ToList();
            numbers.Sort();


            Predicate<long> even = x => { return x % 2 == 0; };
            Predicate<long> odd = x => { return x % 2 != 0; };

            var resultEven = new List<long>();
            var resultOdd = new List<long>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (even(numbers[i]))
                {
                    resultEven.Add(numbers[i]);
                }
                else
                {
                    resultOdd.Add(numbers[i]);
                }
            }


            var result = new List<long>();

            foreach (var ev in resultEven)
            {
                result.Add(ev);
            }
            foreach (var od in resultOdd)
            {
                result.Add(od);
            }
            


            Console.WriteLine(string.Join(" ",result));
            //Console.WriteLine($"{string.Join(" ", resultEven)} {string.Join(" ", resultOdd)}");
        }
    }
}
