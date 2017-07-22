namespace Pairs
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int k = 0; k < numbers.Length; k++)
                {
                    if (numbers[i] - numbers[k] == diff)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
