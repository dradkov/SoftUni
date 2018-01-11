namespace _04.RemoveOddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();


            List<int> result = numbers.ToList();

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentElement = numbers[i];

                int countTimes = numbers.Count(c => c.Equals(currentElement));

                if (countTimes % 2 != 0)

                {
                    result.Remove(currentElement);
                }

            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
