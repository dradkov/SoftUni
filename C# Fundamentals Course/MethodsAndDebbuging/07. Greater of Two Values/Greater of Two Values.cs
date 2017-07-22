using System;

class Program
{
    static void Main()
    {
        var type = Console.ReadLine();
        if (type == "int")
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int max = Getmax(firstNum, secondNum);
            Console.WriteLine(max);

        }
        else if (type == "char")
        {
            char firstChar = Console.ReadLine()[0];
            char secondChar = Console.ReadLine()[0];
            char max = Getmax(firstChar, secondChar);
                  
            Console.WriteLine(max);
        }
        else if (type == "string")
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();
           string max = Getmax(firstString, secondString);

            Console.WriteLine(max);
        }

    }

    private static int Getmax(int firstNum, int secondNum)
    {
        if (firstNum > secondNum)
        {
            return firstNum;
        }
        else
        {
            return secondNum;
        }
    }
    private static char Getmax(char firstChar, char secondChar)
    {
        if (firstChar.CompareTo(secondChar)>0)
        {
            return firstChar;
        }
        else
        {
            return secondChar;
        }
    }
    private static string Getmax(string firstString, string secondString)
    {
        if (firstString.CompareTo(secondString) > 0)
        {
            return firstString;
        }
        else
        {
            return secondString;
        }
    }
}

