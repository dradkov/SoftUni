namespace _05.CountofOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToList();

            int currentnum = -1;

            for (int i = 0; i < numbers.Count; i++)
            {

                if (currentnum == numbers[i])
                {
                    continue;
                }


                currentnum = numbers[i];

                Console.WriteLine($"{currentnum} -> {numbers.Count(e => e.Equals(currentnum))} times");
            }
        }
    }
}
