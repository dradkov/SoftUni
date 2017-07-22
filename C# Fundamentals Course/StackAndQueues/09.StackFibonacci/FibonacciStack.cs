namespace StackFibonacci
{
    using System;
    using System.Collections.Generic;

    class FibonacciStack
    {
        static void Main(string[] args)
        {
            var n = ulong.Parse(Console.ReadLine());

            var fabiunachiStack = new Stack<ulong>();

            fabiunachiStack.Push(1);
            fabiunachiStack.Push(1);

            for (ulong i = 0; i < n; i++)
            {
                ulong first = fabiunachiStack.Pop();
                ulong second = fabiunachiStack.Pop();

                fabiunachiStack.Push(first);
                fabiunachiStack.Push(first + second);


            }

            fabiunachiStack.Pop();

            Console.WriteLine(fabiunachiStack.Peek());
        }
    }
}
