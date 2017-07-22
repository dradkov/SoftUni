using System;

class Program
{
    static void Main()
    {
        
        
        
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());

        const decimal eps = 0.000001M;
        decimal diff = (decimal)a - (decimal)b;

        if (diff < 0)
        {
            diff = -diff;
        }
        if (diff < eps)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}


