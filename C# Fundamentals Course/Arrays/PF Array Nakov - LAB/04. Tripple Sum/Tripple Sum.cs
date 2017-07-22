namespace Triple
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var count = 0;

            for (int a = 0; a < input.Length; a++) /*обхождаме всички позиции веднъж*/
            {
                for (int b = a + 1; b < input.Length; b++) /*обхождаме всички поз. втори път */
                {
                    var sum = input[a] + input[b]; /*числото на a позиция + числото на b позиция*/
                    if (input.Contains(sum)) /*ако съдържа сумата от а + b и я има сред числята в масива  */
                                             //Пример : 6 5 2 3 ,ако сумата на а+б = на едно от числата 6 5 2 3;
                    {
                        Console.WriteLine($"{input[a]} + {input[b]} == {sum}");
                        count++;
                    }

                }
            }
            if (count == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}

