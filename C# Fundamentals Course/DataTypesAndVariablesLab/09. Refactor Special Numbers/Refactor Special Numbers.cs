using System;

class Program
{
    static void Main()
    {
        using System;

class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int digits = i;

                while (digits > 0)
                {
                    sum += digits % 10;
                    digits /= 10;

                }

                bool isSpecialNums = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine($"{i} -> {isSpecialNums}");
            }
        }
    }
}
}

