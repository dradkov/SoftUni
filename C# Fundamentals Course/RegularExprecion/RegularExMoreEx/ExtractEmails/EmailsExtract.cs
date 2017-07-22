namespace ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    class EmailsExtract
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@(?:[a-z]+\-?[a-z]+\.)+[a-z]+\-?[a-z]+)\b";

            Regex emailRegEx = new Regex(pattern);

            MatchCollection matches = emailRegEx.Matches(input);



            foreach (var match in matches)
            {
                string matchString = match.ToString();

                if (!matchString.StartsWith("-") || matchString.StartsWith(".") || matchString.StartsWith("_") ||
                    matchString.EndsWith("-") || matchString.EndsWith(".") || matchString.EndsWith("_"))

                {
                    Console.WriteLine(match);
                }

            }
        }
    }
}