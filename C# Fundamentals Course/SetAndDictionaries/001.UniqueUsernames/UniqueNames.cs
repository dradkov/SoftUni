namespace UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class UniqueNames
    {
        static void Main()
        {
            var numNames = int.Parse(Console.ReadLine());
            var tt = 1;

            var set = new HashSet<string>();
            for (int i = 0; i < numNames; i++)
            {
                var name = Console.ReadLine();
                set.Add(name);
            }
            Console.WriteLine();
            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
