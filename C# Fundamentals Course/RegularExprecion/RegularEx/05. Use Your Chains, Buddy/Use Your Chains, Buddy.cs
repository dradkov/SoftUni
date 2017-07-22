namespace Use
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;

    class UseYourChainsBuddy
    {
        static void Main()
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            string html = Console.ReadLine();
            StringBuilder text = new StringBuilder();

            //extract p tag content:
            string pTagContents = @"<\s*p\s*>([^<]+?)<\s*\/p\s*>";
            Regex regexPCont = new Regex(pTagContents, RegexOptions.IgnoreCase);
            Regex regexNotSmallLetter = new Regex(@"[^a-z0-9]");
            foreach (Match match in regexPCont.Matches(html))
            {
                String pContent = match.Groups[1].Value;
                pContent = regexNotSmallLetter.Replace(pContent, " ");
                pContent = Regex.Replace(pContent, @"\s+", " ");
                text.Append(pContent);
            }

            //decrypt text:
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (Char.IsLower(ch))
                {
                    if (ch >= 'a' && ch < 'n')
                        ch = (char)(ch + 13);
                    else
                        ch = (char)(ch - 13);
                    text[i] = ch;
                }
            }

            Console.WriteLine(text);
        }
    }
}