using System;


class Program
{
    static void Main()
    {
        string variableHexNum = Console.ReadLine();      
        int firstNum = Convert.ToInt32(variableHexNum, 16);

        Console.WriteLine(firstNum);
       
    }
}

