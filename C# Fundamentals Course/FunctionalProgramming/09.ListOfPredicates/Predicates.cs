namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Predicates
    {
        static void Main()
        {
            int range = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = new int[range];
            for (int i = 1; i <= range; i++)
            {
                numbers[i - 1] = i;
            }

            divisors = divisors.Distinct().ToArray();

            List<int> divisibleNumbers = GetDivisible(numbers, divisors, (x, y) => x % y == 0);
            Console.WriteLine(string.Join(" ", divisibleNumbers));
        }

        private static List<int> GetDivisible(int[] numbers, int[] divisors, Func<int, int, bool> pred)
        {
            List<int> newNumbers = new List<int>();
            bool isDivisible;
            for (int i = 0; i < numbers.Length; i++)
            {
                isDivisible = true;
                for (int j = 0; j < divisors.Length; j++)
                {
                    if (!pred(numbers[i], divisors[j]))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    newNumbers.Add(numbers[i]);
                }
            }

            return newNumbers;
        }
    }
}
