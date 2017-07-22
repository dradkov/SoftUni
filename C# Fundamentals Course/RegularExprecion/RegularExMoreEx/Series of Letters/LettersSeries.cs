namespace Series_of_Letters
{
    using System;
    using System.Text.RegularExpressions;

    class LettersSeries
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var regex = new Regex(@"(.)\1+");
            Console.WriteLine(regex.Replace(text, "$1"));
        }
    }
}
