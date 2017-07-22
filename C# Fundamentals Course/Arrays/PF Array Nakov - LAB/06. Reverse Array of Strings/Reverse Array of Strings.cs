namespace ReverseStrings
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {

            var input = Console.ReadLine().Split().ToArray();

            var arr = input.Reverse();

            Console.WriteLine(string.Join(" ", arr));

        }
    }
}

