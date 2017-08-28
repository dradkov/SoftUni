namespace Regeh
{

    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {


            string input = Console.ReadLine();

            List<string> result = new List<string>();

            Regex regex = new Regex(@"\[\w+<(\d+)REGEH(\d+)>\w+\]");


            MatchCollection mathMatch = regex.Matches(input);


            int firstDigit;
            int secondDigit;

            int currentIndex = 0;

            string charckter = string.Empty;


            foreach (Match match in mathMatch)
            {
                firstDigit = int.Parse(match.Groups[1].Value);
                secondDigit = int.Parse(match.Groups[2].Value);


                currentIndex += firstDigit;

                if (currentIndex >= input.Length)
                {

                    charckter = input[currentIndex % input.Length + 1].ToString();
                }
                else
                {
                    charckter = input[currentIndex].ToString();
                }

                result.Add(charckter);

                currentIndex += secondDigit;
                if (currentIndex >= input.Length)
                {

                    charckter = input[currentIndex % input.Length + 1].ToString();
                }
                else
                {
                    charckter = input[currentIndex].ToString();
                }

                result.Add(charckter);
            }

            Console.WriteLine(string.Join("", result));

        }
    }


}

