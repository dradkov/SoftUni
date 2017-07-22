namespace CountUppercaseWords
{
    using System;
    using System.Linq;

    public class CountUpCaseWords
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries).ToList();

            var result = text.Where(w => w[0] == w.ToUpper()[0]).ToList();

            Console.WriteLine(string.Join("\n",result));
        }
    }
}
