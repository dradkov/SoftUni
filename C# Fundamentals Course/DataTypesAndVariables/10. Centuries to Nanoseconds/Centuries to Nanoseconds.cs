using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        byte centuries = byte.Parse(Console.ReadLine());

        short years = (short)(centuries * 100);
        int days = (int)(years * 365.2422);
        int hours = days * 24;
        long minutes = hours * 60;
        long seconds = minutes * 60;
        long miliseconds = seconds * 1000;
        long microseconds = miliseconds * 1000;
        BigInteger nanoseconds = BigInteger.Multiply(microseconds, 1000);

        Console.Write($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {miliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");

    }
}

