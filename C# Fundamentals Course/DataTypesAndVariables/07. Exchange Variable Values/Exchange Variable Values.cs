using System;

class Program
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        int newA = b;
        int newB = a;

        Console.WriteLine("Before: ");
        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");
        Console.WriteLine("After: ");
        Console.WriteLine($"a = {newA}");
        Console.WriteLine($"b = {newB}");
    }
}

