namespace UnicodeCharacters
{
    using System;
    using System.Text;

    public class Unicode
    {
        static void Main()
        {
            var word = Console.ReadLine();


            var sb = new StringBuilder();

            foreach (var symbol in word)
            {
               sb.Append( "\\u" + ((int)symbol).ToString("X4").ToLower());
            }
            Console.WriteLine(sb);
        }
    }
}
