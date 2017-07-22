namespace OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StafOffice
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            var dicty = new Dictionary<string, Dictionary<string, long>>();


            for (int i = 0; i < lines; i++)
            {
                var information = Console.ReadLine();

                var spliter = information.Split(new[] { ' ', '|', '-' }, StringSplitOptions.RemoveEmptyEntries);

                var name = spliter[0];
                var quntity = long.Parse(spliter[1]);
                var product = spliter[2];

                if (!dicty.ContainsKey(name))
                {
                    dicty.Add(name, new Dictionary<string, long>());
                }
                if (!dicty[name].ContainsKey(product))
                {
                    dicty[name].Add(product, 0);
                }
                dicty[name][product] += quntity;

            }


            var ordeded = dicty.OrderBy(x => x.Key);


            foreach (var comp in ordeded)
            {
                Console.Write($"{comp.Key}: ");
                var sb = new StringBuilder();
                foreach (var item in comp.Value)
                {
                    sb.Append(item.Key).Append("-").Append(item.Value).Append(", ");
                }
                sb.Length -= 2;
                Console.WriteLine(sb);
            }
        }
    }
}
