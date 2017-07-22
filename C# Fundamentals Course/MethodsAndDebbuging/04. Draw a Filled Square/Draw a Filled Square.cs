using System;

class Program
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        PrintUpperLine(n);
        PrintMiddLine(n);      
        PrintUpperLine(n);
    }

    private static void PrintMiddLine(int n)
    {
        for (int i = 0; i < n-2; i++)
        {


            Console.Write("-");
            for (int k = 1; k < n; k++)
            {
                Console.Write("\\/");

            }
            Console.Write("-");
            Console.WriteLine();
        }
    }

    private static void PrintUpperLine(int n)
    {
        Console.WriteLine(new string('-', n * 2));
    }
}

