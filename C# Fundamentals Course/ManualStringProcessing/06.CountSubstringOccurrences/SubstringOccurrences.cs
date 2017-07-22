namespace CountSubstringOccurrences
{
    using System;

    public class SubstringOccurrences
    {
        static void Main()
        {
            var text = Console.ReadLine().ToLower();
            var patern = Console.ReadLine().ToLower();

            var index = text.IndexOf(patern);

            var count = 0;
            while (index != -1)
            {
                count++;

                index = text.IndexOf(patern, index + 1);
            }

            Console.WriteLine(count);
        }
 
    }
}
