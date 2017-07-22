namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class BasicStack
    {
        static void Main()
        {
            var NSX = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numbersInStack = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            

            var n = NSX[0];
            var s = NSX[1];
            var x = NSX[2];

            var stackNumbers = new Stack<int>();

            if (numbersInStack.Length>=n || numbersInStack.Length>0)
            {
                var firstNelemnts = numbersInStack.Take(n).ToList();

                foreach (var nums in firstNelemnts)
                {
                    stackNumbers.Push(nums);
                }

            }       

            if (stackNumbers.Count >= s)
            {
                for (int i = 0; i < s; i++)
                {
                    stackNumbers.Pop();
                }
            }
           
            if (stackNumbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stackNumbers.Count >0)
                {
                    foreach (var item in stackNumbers)
                    {
                        Console.WriteLine(stackNumbers.Min());
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("0");
                }
                
            }
        }
    }
}
