namespace ReverseNums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseNumbers
    {
        static void Main()
        {

            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);


            var stackNumbers = new Stack<int>();

            foreach (var num in numbers)
            {
                stackNumbers.Push(num);
            }


            if (stackNumbers.Count > 0)
            {
                foreach (var num in stackNumbers)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }





        }
    }
}
