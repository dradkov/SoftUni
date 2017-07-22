namespace Equal
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool IsFound = false;

            for (int currentElement = 0; currentElement < numbers.Length; currentElement++)
            {
                var leftSum = 0;
                var rightSum = 0;

                for (int i = currentElement + 1; i < numbers.Length; i++)
                {
                    rightSum += numbers[i];
                }
                for (int i = 0; i < currentElement; i++)
                {
                    leftSum += numbers[i];
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(currentElement);
                    IsFound = true;
                }

            }
            if (!IsFound)
            {
                Console.WriteLine("no");
            }

        }
    }
}
