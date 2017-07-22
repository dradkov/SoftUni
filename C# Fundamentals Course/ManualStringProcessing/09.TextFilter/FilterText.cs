namespace TextFilter
{
    using System;

    public class FilterText
    {
        static void Main()
        {
            var banWords = Console.ReadLine()
               .Split(new[] { ' ', '\t', '\n', '\r',',' }, StringSplitOptions.RemoveEmptyEntries);

            var text = Console.ReadLine();

            foreach (var banword in banWords)
            {
                if (text.Contains(banword))
                {
                    text = text.Replace(banword, new string('*', banword.Length));
                }
            }

            Console.WriteLine(text);


        }
    }
}
