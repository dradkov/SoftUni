namespace FoldAndSum
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = numbers.Length / 4;

            int[] middleElements = new int[2 * k];

            for (int i = 0; i < middleElements.Length; i++)
            {
                middleElements[i] = numbers[k + i];
            }

            int[] firstKElements = new int[k];

            for (int i = 0; i < firstKElements.Length; i++)
            {
                firstKElements[i] = numbers[i];
            }

            int[] lastKElements = new int[k];

            for (int i = 0; i < lastKElements.Length; i++)
            {
                lastKElements[i] = numbers[i + 3 * k];
            }

            Array.Reverse(firstKElements);
            Array.Reverse(lastKElements);

            int[] firstAndLastEl = new int[2 * k];

            for (int i = 0; i < firstAndLastEl.Length; i++)
            {
                if (i < k)
                {
                    firstAndLastEl[i] = firstKElements[i];
                }
                else
                {
                    firstAndLastEl[i] = lastKElements[i - k];
                }
            }

            for (int i = 0; i < middleElements.Length; i++)
            {
                middleElements[i] += firstAndLastEl[i];
            }
            Console.WriteLine(string.Join(" ", middleElements));
        }
    }
}

