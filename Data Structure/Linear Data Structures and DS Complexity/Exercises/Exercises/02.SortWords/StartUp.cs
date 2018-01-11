namespace _02.SortWords
{
    using System;

    using System.Linq;

    public class StartUp
    {

        public static void Main(string[] args)
        {
            string[] letters = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);


            string[] result = letters.OrderBy(x => x).ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
