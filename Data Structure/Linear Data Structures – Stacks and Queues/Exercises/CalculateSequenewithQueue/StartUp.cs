namespace CalculateSequenewithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();

            List<int> result = new List<int>();

            result.Add(n);

            queue.Enqueue(n);

            while (result.Count < 50)
            {
                var firstOperation = queue.Peek() + 1;

                queue.Enqueue(firstOperation);

                var secondOperation = (2 * queue.Peek()) + 1;

                queue.Enqueue(secondOperation);
 
                var thirdOperation = queue.Peek() + 2;
                queue.Enqueue(thirdOperation);

                queue.Dequeue();

                result.Add(firstOperation);
                result.Add(secondOperation);
                result.Add(thirdOperation);

            }

            Console.WriteLine(string.Join(", ", result.Take(50)));


        }
    }
}
