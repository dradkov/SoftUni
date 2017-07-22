using System;

class Program
{
    static void Main()
    {
        int firstAsciiNum = int.Parse(Console.ReadLine());
        int secondAsciiNum = int.Parse(Console.ReadLine());

        for (int i = firstAsciiNum; i <= secondAsciiNum; i++)
        {
            Console.Write("{0} ",(char)i);
        }
    }
}

