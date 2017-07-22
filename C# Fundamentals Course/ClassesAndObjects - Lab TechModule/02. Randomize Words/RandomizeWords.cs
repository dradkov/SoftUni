namespace RandomizeWords
{
    using System;
   
    class RandomizeWords
    {
        static void Main()
        {
            var words = Console.ReadLine().Split();

            var randomWords = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                var currentWord = words[i];
                var secondWord = randomWords.Next(0, words.Length);
                words[i] = words[secondWord];
                words[secondWord] = currentWord;
            }
            Console.WriteLine(string.Join("\r\n",words));
        }
    }
}
