namespace BigFactorial
{
    using System;
    using System.Numerics;

    class BigFactorial
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            BigInteger factoriel = 1;

            for (int i = 1; i <= n; i++)
            {
                factoriel *= i;
            }

            Console.WriteLine(factoriel);
        }
    }
}
