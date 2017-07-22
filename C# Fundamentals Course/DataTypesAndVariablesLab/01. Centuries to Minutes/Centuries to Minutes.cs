using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int years = n *100;
        int days = (int)(years* 365.2422);
        int hours = 24*days;
        int minutes = hours*60;

        Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes",n,years,days,hours,minutes);
    }
}

