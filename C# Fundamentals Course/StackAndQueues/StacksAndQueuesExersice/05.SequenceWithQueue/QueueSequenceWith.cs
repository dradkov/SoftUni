namespace SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    class QueueSequenceWith
    {
        static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var numInQueue = new Queue<long>();

            var result = new List<long>();

            result.Add(n);

            numInQueue.Enqueue(n);

            while (result.Count < 50)
            {


                var firstOperation = numInQueue.Peek() + 1;
                numInQueue.Enqueue(firstOperation);

                var secondOperation = (numInQueue.Peek() * 2) + 1;
                numInQueue.Enqueue(secondOperation);

                var thirdOperation = firstOperation + 1;
                numInQueue.Enqueue(thirdOperation);

                numInQueue.Dequeue();

                result.Add(firstOperation);
                result.Add(secondOperation);
                result.Add(thirdOperation);

            }

            Console.WriteLine(string.Join(" ", result.Take(50)));
        }
    }
}
