namespace CharacterMultiplier
{
    using System;
    using System.Linq;

    public class MultiplierCharacter
    {
        static void Main()
        {
            var words = Console.ReadLine().Split().ToArray();

            var firstWord = words[0];
            var secondWord = words[1];

            var firstInChar = firstWord.ToCharArray();
            var secondInChar = secondWord.ToCharArray();

            var sum = 0;

            if (firstWord.Length > secondWord.Length)
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    if (i < secondWord.Length)
                    {
                        sum += firstInChar[i] * secondInChar[i];
                    }
                    else
                    {
                        sum += firstInChar[i];
                    }

                }
            }
            else if (secondWord.Length > firstWord.Length)
            {
                for (int i = 0; i < secondWord.Length; i++)
                {
                    if (i < firstWord.Length)
                    {
                        sum += firstInChar[i] * secondInChar[i];
                    }
                    else
                    {
                        sum += secondInChar[i];
                    }

                }
            }
            else
            {

                for (int i = 0; i < secondWord.Length; i++)
                {

                    sum += firstInChar[i] * secondInChar[i];

                }
            }

            Console.WriteLine(sum);
        }

    }
}

