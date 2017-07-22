using System;

class Program
{
    static void Main()
    {
        double widht = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        double perimeter = (2 * widht) + (2 * height);
        double area = widht * height;      
        double diagonal = Math.Sqrt((widht*widht)+(height*height));

        Console.WriteLine(perimeter);
        Console.WriteLine(area);
        Console.WriteLine(diagonal);

    }
}

