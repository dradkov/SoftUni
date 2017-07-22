namespace Condence
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();



            while (input.Length >= 2)
            {
                var result = new int[input.Length - 1];
                for (int i = 0; i < input.Length - 1; i++)
                {
                    result[i] = input[i] + input[i + 1];
                }
                input = result;
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}

