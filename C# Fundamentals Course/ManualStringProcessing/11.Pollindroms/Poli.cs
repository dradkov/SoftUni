namespace Pollindroms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Poli
    {
        static void Main()
        {
            var separator = new[] { ' ', ',', '!', '?', '.','\t','\n','\r' };

            var text = Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList();
                

            var pollindroms = new SortedSet<string>();

            foreach (var word in text)
            {
                if (IsPolindrom(word))
                {
                    pollindroms.Add(word);
                }
            }
            Console.WriteLine($"[{string.Join(", ", pollindroms)}]");



        }
        public static bool IsPolindrom(string word)
        {
            if (word.Length == 1)
            {
                return true;
            }
            for (int i = 0; i < word.Length / 2; i++)
                {
                    if (word[i] != word[word.Length - i - 1])
                    {
                        return false;
                    }

                }
            
            return true;

        }
    }
}
