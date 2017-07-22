namespace ConcatenateStrings
{
    using System;
    using System.Text;

    public class StringsConcat
    {
        static void Main()
        {
            var numWords = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();

            for (int i = 0; i < numWords; i++)
            {
                var word = Console.ReadLine();
                builder.Append(word);
                builder.Append(" ");
            }

            Console.WriteLine(builder);

        }
    }
}
