
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        LinkedQueue<int> node = new LinkedQueue<int>();

        node.Enqueue(3);
        node.Enqueue(5);
        node.Enqueue(7);
        node.Enqueue(9);

        Console.WriteLine(string.Join(" ",node.ToArray()));
    }
}

