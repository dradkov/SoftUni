using System;

class Program
{
    static void Main()
    {
        double firstNum = double.Parse(Console.ReadLine());
        double secondNum = double.Parse(Console.ReadLine());
        double toPower = RiseToPower(firstNum, secondNum);
        Console.WriteLine(toPower);
    }

    private static double RiseToPower(double firstNum, double secondNum)
    {
        return Math.Pow(firstNum, secondNum);
    }
}

