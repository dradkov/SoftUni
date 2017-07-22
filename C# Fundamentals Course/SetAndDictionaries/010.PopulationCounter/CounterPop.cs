namespace PopulationCounter
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CounterPop
    {
        static void Main(string[] args)
        {
            string entryData = Console.ReadLine().Trim();

            var countryData = new Dictionary<string, List<string>>();
            var cityData = new Dictionary<string, long>();
            var countryTotalData = new Dictionary<string, long>();

            while (!entryData.Equals("report"))
            {

                string[] arrEntry = entryData.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);


                var city = arrEntry[0];
                var country = arrEntry[1];
                var population = long.Parse(arrEntry[2]);

                if (!countryData.ContainsKey(country))
                {
                    countryData.Add(country, new List<string>());
                }
                if (!cityData.ContainsKey(city))
                {
                    cityData.Add(city, 0);
                }
                if (!countryTotalData.ContainsKey(country))
                {
                    countryTotalData.Add(country, 0);
                }


                countryData[country].Add(city);
                cityData[city] += population;
                countryTotalData[country] += population;

                entryData = Console.ReadLine();
            }


            foreach (var country in countryTotalData.OrderByDescending(coun => coun.Value))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value})");

                foreach (var city in cityData.OrderByDescending(c => c.Value))
                {
                    foreach (var eachCity in countryData[country.Key])
                    {
                        if (eachCity == city.Key)
                        {
                            Console.WriteLine($"=>{eachCity}: {city.Value}");
                        }
                    }
                }
            }

        }
    }

}
