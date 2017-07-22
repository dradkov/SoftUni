﻿
namespace Sum
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var biggest = Math.Max(arr1.Length, arr2.Length);

            var result = new int[biggest];


            for (int i = 0; i < biggest; i++)
            {
                result[i] = arr1[i % arr1.Length] + arr2[i % arr2.Length];
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}

