namespace Kittens.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using Kittens.App.Models;
    using Kittens.App.Services.Content;
    using Kittens.Data;
    using Kittens.Models;
    using Kittens.Models.Enums;

    public class KittenService : IKittenService
    {


        


        public bool Create(string name, string age, string breed)
        {
            using (KittenDbContext db = new KittenDbContext())
            {
                if (db.Kittens.Any(k => k.Name == name))
                {
                    return false;
                }

                int parsedAge = this.ParsedAge(age);

                BreedType parsedBreed = this.ParseBreed(breed);

                if (parsedBreed == BreedType.Udefined || parsedAge == -1)
                {
                    return false;
                }


                Kitten cat = new Kitten
                {
                    Name = name,
                    Age = parsedAge,
                    Breed = parsedBreed
                };

                db.Kittens.Add(cat);
                db.SaveChanges();

                return true;
            }
        }

        public IEnumerable<ShowAllMaci> All()
        {
            using (KittenDbContext db = new KittenDbContext())
            {
                return db.Kittens
                    .Select(k => new ShowAllMaci
                    {
                        Name = k.Name,
                        Age = k.Age,
                        Breed = k.Breed,
                        Url = "https://timeheroes.org/media/cache/97/18/9718f49e14e5774b5554e12ac14c3b8e.jpg"
                    })
                    .ToList();
            }
           
        }


        private int ParsedAge(string age)
        {

            try
            {
                int num = int.Parse(age);


                if (num < 0 || num > 18)
                {
                    return -1;
                }
                return num;
            }
            catch (Exception )
            {
                return -1;
            }

        }

        private BreedType ParseBreed(string breed)
        {


            try
            {
                BreedType content = (BreedType)Enum.Parse(typeof(BreedType), breed);
                return content;
            }
            catch (Exception)
            {
                return default(BreedType);
            }






        }
    }
}
