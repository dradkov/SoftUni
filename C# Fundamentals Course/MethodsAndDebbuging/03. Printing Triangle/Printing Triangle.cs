using System;

class Program
{
   
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        PrintUpperTriangle(n);
        PrintBottomTriangle(n);
    }

    private static void PrintBottomTriangle(int n)
    {
        for (int i = n-1; i > 0; i--)
        {
            PrintLine(1,i);
        }
        
    }

    private static void PrintUpperTriangle(int n)
    {
        for (int i = 1; i <= n; i++)
        {

            PrintLine(1, i);
        }
    }

    private static void PrintLine(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }
}

