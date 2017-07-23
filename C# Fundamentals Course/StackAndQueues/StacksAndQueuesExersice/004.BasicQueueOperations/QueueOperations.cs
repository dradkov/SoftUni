namespace BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class QueueOperations
    {
        static void Main()
        {

            var commandInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var commandLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            var n = commandInfo[0];
            var s = commandInfo[1];
            var x = commandInfo[2];


            if (n>=commandLine.Length)
            {
                for (int i = 0; i < n; i++)
                {
                    queue.Enqueue(commandLine[i]);
                }
            }

            if (queue.Count>0)
            {
                for (int i = 0; i < s; i++)
                {
                    queue.Dequeue();
                }
                if (queue.Count>0)
                {
                    if (queue.Contains(x))
                    {
                        Console.WriteLine("true");
                    }
                    else
                    {
                        Console.WriteLine(queue.Min());
                    }
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
            
        }
    }
}
