namespace MagicWxchangeableWords
{
    using System;
    using System.Collections.Generic;

    public class MagigWords
    {
        static void Main(string[] args)
        {

            Dictionary<char, char> dict = new Dictionary<char, char>();

            var input = Console.ReadLine().Split();
            var one = input[0];
            var two = input[1];

            int minL = Math.Min(one.Length, two.Length);
            bool isExchangeable = true;

            for (int i = 0; i < minL; i++)
            {
                if (!dict.ContainsKey(one[i]))
                {
                    if (!dict.ContainsValue(two[i]))
                    {
                        dict.Add(one[i], two[i]);
                    }
                    else
                    {
                        isExchangeable = false;
                        break;
                    }

                }
                else
                {
                    if (dict[one[i]] != two[i])
                    {
                        isExchangeable = false;
                        break;
                    }
                }
            }

            var rest = string.Empty;

            if (one.Length > two.Length)
            {
                rest = one.Substring(minL);
            }
            else
            {
                rest = two.Substring(minL);
            }

            foreach (char ch in rest)
            {
                if (!dict.ContainsValue(ch) && !dict.ContainsKey(ch))
                {
                    isExchangeable = false;
                }
            }
            Console.WriteLine(isExchangeable.ToString().ToLower());

        }
    }
}
