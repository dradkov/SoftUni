namespace MapDistricts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DistrictMap
    {
        static void Main()
        {
            var cityData = new Dictionary<string, List<long>>();

            var inputInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var filterNumber = long.Parse(Console.ReadLine());


            for (int i = 0; i < inputInfo.Length; i++)
            {
                var splitCity = inputInfo[i].Split(':');

                var city = splitCity[0];
                var population = long.Parse(splitCity[1]);


                if (!cityData.ContainsKey(city))
                {
                    cityData.Add(city, new List<long>());
                }
                cityData[city].Add(population);

            }

            if (cityData.Any())
            {
                var ordered = cityData.OrderByDescending(x => x.Value.Sum());

                foreach (var city in ordered)
                {

                    var valueSum = city.Value.Sum();
                    var orderValue = city.Value.OrderByDescending(x => x).Take(5);

                    if (valueSum > filterNumber)
                    {
                        Console.WriteLine($"{city.Key}: {string.Join(" ", orderValue)}");
                    }

                }
            }



        }
    }
}