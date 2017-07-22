using System;

class Program
{
    static void Main()
    {
        int inputNum = int.Parse(Console.ReadLine());
        for (int n1 = 2; n1 <= inputNum; n1++)
        {
            bool isPrime = true;
            for (int n2 = 2; n2 <= Math.Sqrt(n1); n2++)
            {
                if (n1 % n2 == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine($"{n1} -> {isPrime}");
        }

    }
}

