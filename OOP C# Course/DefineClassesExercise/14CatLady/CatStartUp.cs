namespace CatLady.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CatStartUp
    {
        static void Main()
        {
            var infoCat = Console.ReadLine();
            var siamseCat = new List<Siamese>();
            var cymricCat = new List<Cymric>();
            var streetCat = new List<StreetExtraordinaire>();

            while (infoCat != "End")
            {
                var split = infoCat.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                var breed = split[0].Trim();
                var name = split[1].Trim();
                var param = split[2].Trim();

                if (breed == "StreetExtraordinaire")
                {

                    if (!streetCat.Any(c => c.Name == name))
                    {
                        streetCat.Add(new StreetExtraordinaire(breed, name, long.Parse(param)));
                    }

                }
                else if (breed == "Cymric")
                {
                    if (!cymricCat.Any(c => c.Name == name))
                    {
                        cymricCat.Add(new Cymric(breed, name, decimal.Parse(param)));
                    }

                }
                else if (breed == "Siamese")
                {
                    if (!siamseCat.Any(c => c.Name == name))
                    {
                        siamseCat.Add(new Siamese(breed, name, long.Parse(param)));
                    }
                }

                infoCat = Console.ReadLine();
            }

            var searchName = Console.ReadLine();

            if (siamseCat.Any(c => c.Name == searchName))
            {
                var cat = siamseCat.Where(c => c.Name == searchName).FirstOrDefault();
                Console.WriteLine($"{cat.Breed} {cat.Name} {cat.EarSize}");
            }
            else if (cymricCat.Any(c => c.Name == searchName))
            {
                var cat = cymricCat.Where(c => c.Name == searchName).FirstOrDefault();
                Console.WriteLine($"{cat.Breed} {cat.Name} {cat.FurLength:f2}");
            }
            else if (streetCat.Any(c => c.Name == searchName))
            {
                var cat = streetCat.Where(c => c.Name == searchName).FirstOrDefault();
                Console.WriteLine($"{cat.Breed} {cat.Name} {cat.Decibels}");

            }
        }
    }
}

