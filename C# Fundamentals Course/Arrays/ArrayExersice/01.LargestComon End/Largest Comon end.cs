namespace LargestComonEnd
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine().Split().ToArray();
            var arr2 = Console.ReadLine().Split().ToArray();


            var leftCount = 0;
            var rightCount = 0;

            int smallResult = Math.Min(arr1.Length, arr2.Length);
          
            for (int i = 0; i < smallResult; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    leftCount++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < smallResult; i++)
            {
                if (arr1[arr1.Length-1-i] == arr2[arr2.Length-1-i])
                {
                    rightCount++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(Math.Max(rightCount,leftCount));
        }

           

    }
}
