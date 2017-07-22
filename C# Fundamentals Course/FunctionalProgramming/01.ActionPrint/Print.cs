namespace ActionPrint
{
    using System;
    using System.Linq;

    public class Print
    {
        static void Main()
        {
            var names = Console.ReadLine().Split().ToArray();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
