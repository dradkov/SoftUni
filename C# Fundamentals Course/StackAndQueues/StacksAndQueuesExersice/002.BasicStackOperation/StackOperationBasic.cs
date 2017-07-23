namespace BasicStackOperation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StackOperationBasic
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numcount = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var n = input[0];
            var s = input[1];
            var x = input[2];

            var stack = new Stack<int>();


            if (n <= numcount.Length)
            {
                for (int i = 0; i < n; i++)
                {
                    stack.Push(numcount[i]);
                }            
               

            }

            if (stack.Count >= s)
            {
                for (int i = 0; i < s; i++)
                {
                    stack.Pop();
                }
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
              
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }


        }
    }
}
