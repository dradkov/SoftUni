using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            int sum = 0;
            string digits = i.ToString();
            for (int j = 0; j < digits.Length; j++)
            {
                sum += int.Parse(digits[j].ToString());

            }

            bool isSpecialNums = (sum == 5) || (sum == 7) || (sum == 11);

            Console.WriteLine($"{i} -> {isSpecialNums}");
        }
    }
}

