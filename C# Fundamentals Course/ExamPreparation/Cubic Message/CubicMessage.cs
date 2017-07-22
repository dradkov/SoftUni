namespace CubicMessages
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;


    class Program
    {
        static void Main(string[] args)
        {
            var secretMessage = Console.ReadLine();


            while (!secretMessage.Equals("Over!"))
            {
                var count = Console.ReadLine();



                var regex = new Regex(@"^([0-9]+)([a-zA-Z]{" + count + @"})([^a-zA-Z]*)$");

                var match = regex.Match(secretMessage);

                if (match.Success)
                {
                    var message = match.Groups[2].ToString();
                    Console.Write(message + " == ");

                    List<int> indexes = GetDigitIndex(match);

                    foreach (var item in indexes)
                    {
                        if (0 <= item && item < message.Length)
                        {
                            Console.Write(message[item]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }

                secretMessage = Console.ReadLine();

            }
        }

        private static List<int> GetDigitIndex(Match match)
        {
            var indexes = new List<int>();

            var leftDigits = match.Groups[1].ToString();
            for (int i = 0; i < leftDigits.Length; i++)
            {
                if (char.IsDigit(leftDigits[i]))
                {
                    indexes.Add(int.Parse(leftDigits[i].ToString()));
                }
            }

            var rightDigits = match.Groups[3].ToString();


            for (int i = 0; i < rightDigits.Length; i++)
            {
                if (char.IsDigit(rightDigits[i]))
                {
                    indexes.Add(int.Parse(rightDigits[i].ToString()));
                }
            }

            return indexes;
        }
    }
}
