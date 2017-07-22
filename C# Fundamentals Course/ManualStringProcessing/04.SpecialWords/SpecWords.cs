
namespace SpecialWords
{
    using System;
    using System.Collections.Generic;

    public class SpecWords
    {
        static void Main()
        {
            //( ) [ ] < > , - ! ? and space (‘ ’) 
            var separator = new[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' };

            var specialWords = Console.ReadLine().Split(separator,StringSplitOptions.RemoveEmptyEntries);


            var resultDict = new Dictionary<string, int>();

            for (int i = 0; i < specialWords.Length; i++)
            {
                resultDict.Add(specialWords[i], 0);
            }

            var text = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

            var count = 1;
            for (int i = 0; i < text.Length; i++)
            {
                if (resultDict.ContainsKey(text[i]))
                {
                    resultDict[text[i]] += count;
                }             
                
            }

            foreach (var words in resultDict)
            {
                Console.WriteLine($"{words.Key} - {words.Value}");
            }
        }
    }
}
