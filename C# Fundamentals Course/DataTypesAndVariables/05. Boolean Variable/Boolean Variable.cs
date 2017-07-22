using System;

class Program
{
    static void Main()
    {
        string booleanInput = Console.ReadLine();

        bool isTrue = Convert.ToBoolean(booleanInput);

        Console.WriteLine(isTrue ? "Yes" : "No");
        
    }
}

