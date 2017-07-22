using System;
using System.Text.RegularExpressions;

class SentenExtractor
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine();
        string toCheck = Console.ReadLine();

        Regex rgx = new Regex(@"(\w[^.!?]*)?(?i:\b" + word + @"\b)[^.!?]*[.!?]");
        MatchCollection matches = rgx.Matches(toCheck);
        foreach (var item in matches)
        {
            Console.WriteLine(item);
        }
    }
}