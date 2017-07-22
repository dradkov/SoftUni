namespace ShopingSpree.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingStartUp
    {
        static void Main()
        {
            var listPeople = new List<Person>();
            var listProducts = new List<Product>();

            var info = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in info)
            {
                var split = person.Split('=');

                var name = split[0].Trim();
                var money = decimal.Parse(split[1].Trim());

                try
                {
                    listPeople.Add(new Person(name, money));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            var infoProduct = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var product in infoProduct)
            {
                var split = product.Split('=');

                var name = split[0].Trim();
                var price = decimal.Parse(split[1].Trim());

                try
                {
                    listProducts.Add(new Product(name, price));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }


            var groseries = Console.ReadLine();
            while (groseries != "END")
            {
                var split = groseries.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                var name = split[0];
                var product = split[1];


                if (listPeople.Any(p => p.Name == name))
                {
                    var man = listPeople.Where(p => p.Name == name).First();
                    var prod = listProducts.Where(p => p.Name == product).First();
                    if (man.Money >= prod.Coast)
                    {
                        man.AddProducts(new Product(prod.Name, prod.Coast));
                        man.Money -= prod.Coast;
                        Console.WriteLine($"{man.Name} bought {prod.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{man.Name} can't afford {product}");
                    }
                }



                groseries = Console.ReadLine();
            }




            foreach (var person in listPeople)
            {
                if (person.SeeBag().Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.SeeBag().Select(p => p.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }

            }
        }
    }
}

