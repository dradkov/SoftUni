namespace CompareChar
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            char[] arr1 = Console.ReadLine().Split().Select(char.Parse).ToArray();
            char[] arr2 = Console.ReadLine().Split().Select(char.Parse).ToArray();

            string[] arrayString = { new string(arr1), new string(arr2) };

            Console.WriteLine(string.Join("\n", arrayString.OrderBy(str => str)));

        }
    }
}

