namespace UpperStrings
{
    using System;
    using System.Linq;

    public class UpperString
    {
        static void Main()
        {
            var words = Console.ReadLine().Split().ToArray();

            var result = words.Select(w => w.ToUpper()).ToList();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
