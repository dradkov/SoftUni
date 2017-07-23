namespace HotPotato
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class PotatoHot
    {
        static void Main()
        {
            var children = Console.ReadLine().Split();
            var circleCount = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(children);

            while (queue.Count>1)
            {
                for (int i = 1; i < circleCount; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
