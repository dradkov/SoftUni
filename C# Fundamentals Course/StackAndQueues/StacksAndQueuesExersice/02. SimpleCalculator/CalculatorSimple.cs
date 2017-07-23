namespace SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
 

    class CalculatorSimple
    {
        static void Main()
        {
            var numbers = Console.ReadLine();
            var values = numbers.Split();

            var stack = new Stack<string>(values.Reverse());

            while (stack.Count>1)
            {
                var first = int.Parse(stack.Pop());
                var operand = stack.Pop();
                var second = int.Parse(stack.Pop());

                
                switch (operand)
                {
                    case "+":
                          stack.Push((first + second).ToString());
                        break;
                    case "-": stack.Push((first - second).ToString());
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine(stack.Pop());
        }

    }
}
