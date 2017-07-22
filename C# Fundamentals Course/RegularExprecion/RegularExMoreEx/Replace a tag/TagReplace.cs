
namespace Replace_a_tag
{
    using System;
    using System.Text.RegularExpressions;

    class TagReplace
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                string pattern = @"<a\s+href=([^>]+)>([^<]+)</a>";
                Regex regex = new Regex(pattern);
                string replacement = "[URL href=$1]$2[/URL]";
                string result = Regex.Replace(input, pattern, replacement);
                Console.WriteLine(result);
                input = Console.ReadLine();
            }
           
        }
    }
}
