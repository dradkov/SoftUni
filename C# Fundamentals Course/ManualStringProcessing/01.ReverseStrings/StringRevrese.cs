namespace ReverseStrings
{
    using System;
    using System.Text;

    public class StringRevrese
    {
        static void Main()
        {
            var word = Console.ReadLine().ToCharArray();

            var sb = new StringBuilder();

            for (int i = word.Length - 1; i >= 0; i--)
            {
                sb.Append((char)word[i]);
            }

            Console.WriteLine(sb);



        }
    }
}
