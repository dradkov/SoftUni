namespace MathPotato
{
    using System;
    using System.Collections.Generic;

    class MatPotato
    {


        static void Main(string[] args)
        {
            var children = Console.ReadLine();
            var queue = new Queue<string>(children.Split());

            var circleCount = int.Parse(Console.ReadLine());

            int cycle = 1;




            while (queue.Count > 1)
            {
                for (int i = 0; i < circleCount - 1; i++)
                {
                    var reminder = queue.Dequeue();
                    queue.Enqueue(reminder);


                }

                if (PrimeTool.isPrime(cycle))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                cycle++;
              
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        public class PrimeTool
        {
            public static bool isPrime(int player)
            {
                if ((player & 1) == 0)
                {
                    if (player == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                for (int i = 3; i * i <= player; i += 2)
                {
                    if ((player % i) == 0)
                    {
                        return false;
                    }
                }

                return player != 1;
            }

        }
    }
}
