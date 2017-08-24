using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BasicMarkupLanguage
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static int lineNumber = 1;

        public static void Main()
        {
            var spliter = new char[] { ' ', '<', '>', '=', '\"' };

            string pattern = @"\s*<\s*([a-z]+)\s+(?:value\s*=\s*""\s*(\d+)\s*""\s+)?[a-z]+\s*=\s*""([^""]*)""\s*\/>\s*";
            Regex rgx = new Regex(pattern);

            string input;

            while ((input = Console.ReadLine()) != "<stop/>")
            {

                Match match = rgx.Match(input);

                string command = match.Groups[1].Value;

                string wordToOperate = match.Groups[3].Value;


                switch (command)
                {
                    case "inverse":
                        InverseWord(wordToOperate);
                        break;
                    case "reverse":
                        ReverseWord(wordToOperate);
                        break;
                    case "repeat":
                        RepeatWord(wordToOperate, int.Parse(match.Groups[2].Value));
                        break;

                }
            }

        }
        private static void ReverseWord(string wordToOperate)
        {
            if (wordToOperate.Length > 0)
            {
                Console.WriteLine($"{lineNumber++}. {string.Join(string.Empty, wordToOperate.Reverse())}");
            }
        }
        private static void InverseWord(string wordToOperate)
        {
            if (wordToOperate.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (char ch in wordToOperate)
                {
                    if (char.IsUpper(ch))
                    {
                        sb.Append(char.ToLower(ch));
                    }
                    else if (char.IsLower(ch))
                    {
                        sb.Append(char.ToUpper(ch));
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }
                Console.WriteLine($"{lineNumber++}. {sb}");
            }
        }
        private static void RepeatWord(string wordToOperate, int value)
        {
            if (value > 0 && wordToOperate.Length > 0)
            {
                for (int i = 0; i < value; i++)
                {
                    Console.WriteLine($"{lineNumber++}. {wordToOperate}");
                }
            }
        }
    }
}
