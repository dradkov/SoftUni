namespace DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    class BinaryConverter
    {
        static void Main()
        {
            var numberInput = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            if (numberInput==0)
            {
                Console.WriteLine("0");
            }

            while (numberInput != 0 )
            {
                stack.Push(numberInput % 2);
                numberInput /= 2;
            }

            while (stack.Count!=0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
