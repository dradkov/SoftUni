namespace PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TablePeriodic
    {
        static void Main()
        {
            var numElements = int.Parse(Console.ReadLine());

            var set = new SortedSet<string>();

            for (int i = 0; i < numElements; i++)
            {
                var elements = Console.ReadLine()
                         .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                         

                set.UnionWith(elements);
             
            }

            Console.WriteLine(string.Join(" ",set));
        }
    }
}
