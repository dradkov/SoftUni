namespace Rotate
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());

            int[] sum = new int[input.Length];

            for (int r = 0; r < k; r++)
            {

                var lastDigit = input[input.Length - 1];
                for (int curPossition = input.Length - 1; curPossition > 0; curPossition--)
                {
                    input[curPossition] = input[curPossition - 1];

                }
                input[0] = lastDigit;

                for (int i = 0; i < input.Length; i++)
                {
                    sum[i] += input[i];
                }

            }
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}

