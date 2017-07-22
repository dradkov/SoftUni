namespace AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArithmeticsApplied
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            var commands = Console.ReadLine();

            var result = new List<double>();

            while (commands !="end")
            {
                if (commands == "add")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        result.Add(numbers[i] + 1);
                    }
                    numbers = result;
                }
               else if (commands == "multiply")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        result.Add(numbers[i] * 2);
                    }
                    numbers = result;
                }
                else if (commands == "subtract")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        result.Add(numbers[i] - 1);
                    }
                    numbers = result;
                }
                else if (commands == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));                   
                }

                result = new List<double>();

                commands = Console.ReadLine();
            }
        }
    }
}
