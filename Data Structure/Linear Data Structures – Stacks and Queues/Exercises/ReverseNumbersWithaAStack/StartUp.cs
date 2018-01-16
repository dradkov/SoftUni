namespace ReverseNumbersWithaAStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);


            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{stack.Pop()} ");
            }



        }
    }
}
