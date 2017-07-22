using System;

class MultiplyEvensByOdds
{
    static void Main()
    {
        int number = Math.Abs(int.Parse(Console.ReadLine()));

        int result = MultipliesEvensToOdds(number);
        Console.WriteLine(result);
    }

    static int GetTheSumOfEvenDigits(int number)
    {
        int evenSum = 0;

        while (number > 0)
        {
            int lastDigit = number % 10;
            number = number / 10;

            if (lastDigit % 2 == 0)
            {
                evenSum += lastDigit;
            }
        }

        return evenSum;
    }

    static int GetTheSumOfOddDigits(int number)
    {
        int oddSum = 0;

        while (number > 0)
        {
            int lastDigit = number % 10;
            number = number / 10;

            if (lastDigit % 2 != 0)
            {
                oddSum += lastDigit;
            }
        }

        return oddSum;
    }

    static int MultipliesEvensToOdds(int number)
    {
        int evenSum = GetTheSumOfEvenDigits(number);
        int oddSum = GetTheSumOfOddDigits(number);

        return evenSum * oddSum;
    }
}