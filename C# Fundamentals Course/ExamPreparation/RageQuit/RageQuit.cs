namespace RageQuit
{
    using System;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Linq;

    class RageQuit
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToUpper();

            var patern = @"(\D+)(\d+)";
            var regex = new Regex(patern);
            var matches = regex.Matches(text);

            var output = new StringBuilder();

            foreach (Match match in matches)
            {
                for (int i = 0; i < int.Parse(match.Groups[2].ToString()); i++)
                {
                    output.Append(match.Groups[1].ToString());
                  
                }
            }

           var  count = output.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {count}");
            Console.WriteLine($"{output}");

        }
    }
}
