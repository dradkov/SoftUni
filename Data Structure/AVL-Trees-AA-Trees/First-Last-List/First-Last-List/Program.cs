using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Wintellect.PowerCollections;

public class Program
{
    static void Main(string[] args)
    {
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
      



        Console.WriteLine(items);
    }
}
