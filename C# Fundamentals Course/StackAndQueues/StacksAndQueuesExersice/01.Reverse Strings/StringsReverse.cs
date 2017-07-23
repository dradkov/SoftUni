namespace ReverseStrings
{
    using System;
    using System.Collections.Generic;

    class StringsReverse
    {
        static void Main()
        {
            var words = Console.ReadLine();

            var stack = new Stack<char>();


            for (int i = 0; i < words.Length; i++)
            {
                stack.Push(words[i]);
            }

            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();

        }
    }
}
