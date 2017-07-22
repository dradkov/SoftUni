namespace ExtractSentencesByKeyword
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class ExtractSentencesByKeyword
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();

            var sentences = Console.ReadLine()
                .Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            string pattern = "\\b" + word + "\\b";

            var regex = new Regex(pattern);


            foreach (var item in sentences)
            {
                if (regex.IsMatch(item))
                {
                    Console.WriteLine(item.Trim());
                }
            }

        }
    }
}
