namespace EveNumbersThread
{
    using System;
    using System.Linq;
    using System.Threading;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = nums[0];
            int end = nums[1];

            Thread tread = new Thread(()=>PrintNums(start,end)); 

            tread.Start();
            tread.Join();

            Console.WriteLine("Thread finished work");
        }

        private static void PrintNums(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (i%2==0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
