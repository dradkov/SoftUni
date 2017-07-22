using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());


        for (char n1 = 'a'; n1 < 'a' + n; n1++)
        {
            for (char n2 = 'a'; n2 < 'a' + n; n2++)
            {
                for (char n3 = 'a'; n3 < 'a' + n; n3++)
                {
                    Console.WriteLine($"{n1}{n2}{n3}");
                }
            }
        }
    }
}

