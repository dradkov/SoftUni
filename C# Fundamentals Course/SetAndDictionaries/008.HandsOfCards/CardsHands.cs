namespace HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CardsHands
    {
        static void Main()
        {
            var dictionaryInfo = new Dictionary<string, List<string>>();

            var input = Console.ReadLine();

            while (input != "JOKER")
            {
                var inputSplit = input
                    .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                var name = inputSplit[0];
                var powerLine = inputSplit[1]
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Distinct()
                    .ToList();            

                if (!dictionaryInfo.ContainsKey(name))
                {
                    dictionaryInfo.Add(name, new List<string>());
                }
                dictionaryInfo[name].AddRange(powerLine);

                input = Console.ReadLine();
            }
            Print(dictionaryInfo);
        }

        private static void Print(Dictionary<string, List<string>> dictionaryInfo)
        {
            foreach (var item in dictionaryInfo)
            {
                var name = item.Key;
                var score = item.Value.Distinct().ToList();
                var result = 0;

                foreach (var points in score)
                {
                    var power = points.Substring(0, points.Length - 1);
                    var type = points.Substring(points.Length - 1);

                    var rang = GetRang(power);
                    var suite = GetSuite(type);

                    result += rang * suite;


                }
                Console.WriteLine($"{name}: {result}");

            }

        }

        

        public static int GetSuite(string type)
        {
            var result = 0;

            switch (type)
            {
                case "S": result = 4; break;
                case "H": result = 3; break;
                case "D": result = 2; break;
                case "C": result = 1; break;
                default:
                    break;
            }

            return result;
        }

        public static int GetRang(string power)
        {
            var result = 0;

            switch (power)
            {
                case "2": result = 2; break;
                case "3": result = 3; break;
                case "4": result = 4; break;
                case "5": result = 5; break;
                case "6": result = 6; break;
                case "7": result = 7; break;
                case "8": result = 8; break;
                case "9": result = 9; break;
                case "10": result = 10; break;
                case "J": result = 11; break;
                case "Q": result = 12; break;
                case "K": result = 13; break;
                case "A": result = 14; break;

                default:
                    break;
            }
            return result;
        }
    }
}
