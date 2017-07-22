namespace ConvertFromBaseToBase_N
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class ConvertFromTo
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(BigInteger.Parse).ToList();

            var n = numbers[0];
            var baseNum = numbers[1];

            BigInteger temp = 0;

            string result = string.Empty;

            while (baseNum > 0)
            {
                temp = baseNum % n;
                baseNum /= n;

                result = temp.ToString() + result;
            }
            Console.WriteLine(result);
        }
    }
}
