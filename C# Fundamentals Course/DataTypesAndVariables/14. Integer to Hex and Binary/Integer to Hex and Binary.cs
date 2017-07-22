using System;

class Program
{
    static void Main()
    {
        int value = int.Parse(Console.ReadLine());

        string inHexadecimal = Convert.ToString(value,16).ToUpper();       
        string inBinary = Convert.ToString(value, 2).ToUpper();

        Console.WriteLine(inHexadecimal);
        Console.WriteLine(inBinary);

    }
}

