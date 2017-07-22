using System;

class Program
{
    static void Main()
    {

        double length, width, heigth = 0;

        Console.Write(" Length:");

        length = double.Parse(Console.ReadLine());

        Console.Write(" Width:");

        width = double.Parse(Console.ReadLine());

        Console.Write(" Height:");

        heigth = double.Parse(Console.ReadLine());

        double Volume = (length * width * heigth)/3;

        Console.WriteLine(" Pyramid Volume: {0:F2} ", Volume);




    }
}

