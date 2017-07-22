namespace Extract
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (input.Length <= 1)
            {
                Console.WriteLine(input[0]);
                return;
            }
            if (input.Length % 2 == 0)
            {
                var firstNum = input.Length / 2 - 1;
                var secondNum = input.Length / 2;
                Console.WriteLine($"{input[firstNum]}, {input[secondNum]}");
            }
            else
            {
                var firstNum = input.Length / 2 - 1;
                var secondNum = input.Length / 2;
                var thirdNum = input.Length / 2 + 1;

                Console.WriteLine($"{input[firstNum]}, {input[secondNum]}, {input[thirdNum]} ");
            }
        }
    }
}

