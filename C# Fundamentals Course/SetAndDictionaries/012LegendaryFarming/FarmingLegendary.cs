namespace LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class FarmingLegendary
    {
        static void Main()
        {
            var itemValue = new Dictionary<string, long>();
            itemValue.Add("fragments", 0);
            itemValue.Add("shards", 0);
            itemValue.Add("motes", 0);

            int count = 1;

            while (count != 10)
            {
                var inputInfo = Console.ReadLine().ToLower().Split();

                var obtained = string.Empty;

                for (int i = 1; i < inputInfo.Length; i += 2)
                {
                    var materialValue = int.Parse(inputInfo[i - 1]);
                    var material = inputInfo[i];

                    if (!itemValue.ContainsKey(material))
                    {
                        itemValue.Add(material, 0);
                    }
                    itemValue[material] += materialValue;

                    obtained = ChekedForLegendary(itemValue);

                    if (obtained != string.Empty)
                    {
                        Console.WriteLine($"{obtained} obtained!");
                        break;
                    }
                }
                if (obtained != string.Empty)
                {
                    break;
                }

                count++;
            }
            Print(itemValue);


        }

        private static void Print(Dictionary<string, long> itemValue)
        {
            var rareMaterials = itemValue
               .Take(3)
               .OrderByDescending(x => x.Value)
               .ThenBy(x => x.Key)
               .ToArray();

            var junkMaterials = itemValue.Skip(3).OrderBy(x => x.Key);

            foreach (var rare in rareMaterials)
            {
                Console.WriteLine($"{rare.Key}: {rare.Value}");
            }

            foreach (var junk in junkMaterials)
            {
                Console.WriteLine($"{junk.Key}: {junk.Value}");
            }
        }

        private static string ChekedForLegendary(Dictionary<string, long> itemValue)
        {
            var winner = string.Empty;

            if (itemValue["fragments"]>=250)
            {
                winner = "Valanyr";
                itemValue["fragments"] -= 250;
            }
            if (itemValue["shards"] >= 250)
            {
                winner = "Shadowmourne";
                itemValue["shards"] -= 250;
            }
            if (itemValue["motes"] >= 250)
            {
                winner = "Dragonwrath";
                itemValue["motes"] -= 250;
            }

            return winner;
        }
    }
}
