namespace CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SymbolsCount
    {
        static void Main()
        {

            var charNumbers = new Dictionary<char, int>();
                
            var words = Console.ReadLine().ToCharArray();

            var count = 1;
            foreach (var word in words)
            {
                if (!charNumbers.ContainsKey(word))
                {
                    charNumbers.Add(word, 0);
                }
                charNumbers[word] += count;
            }

            foreach (var word in charNumbers.OrderBy(w=>w.Key))
            {
                Console.WriteLine($"{word.Key}: {word.Value} time/s");
            }
            
        }
    }
}
