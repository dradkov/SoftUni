namespace Reverse
{

    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            int[] arr = new int[input];

            for (int i = 0; i < input; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());

            }

            arr = arr.Reverse().ToArray();

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}

