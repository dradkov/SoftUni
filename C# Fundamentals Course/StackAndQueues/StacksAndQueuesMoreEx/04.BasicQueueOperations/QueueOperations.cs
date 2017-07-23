namespace BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class QueueOperations
    {
        static void Main()
        {
            var command = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numbersForQueue = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var n = command[0];
            var s = command[1];
            var x = command[2];


            var queueNums = new Queue<int>();


            if (numbersForQueue.Length >= n)
            {
                var firstNnums = numbersForQueue.Take(n).ToList();

                foreach (var num in firstNnums)
                {
                    queueNums.Enqueue(num);
                }
            }
            if (queueNums.Count > 0)
            {
                for (int i = 0; i < s; i++)
                {
                    queueNums.Dequeue();
                }
            }

            if (queueNums.Count > 0)
            {
                if (queueNums.Contains(x))
                {
                    Console.WriteLine("true");
                }
               
               
                else
                {
                    Console.WriteLine(queueNums.Min());
                }
            }
            else
            {
                Console.WriteLine("0");
            }
           

        }
    }
}
