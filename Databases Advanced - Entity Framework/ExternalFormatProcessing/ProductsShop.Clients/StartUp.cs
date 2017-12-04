namespace ProductsShop.Clients
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using ProductsShop.Data;
    using ProductShop.Models;


    public class StartUp
    {
        public static void Main(string[] args)
        {

            var db = new ProductsShopDbContext();

            using (db)
            {
                //ResetDb(db);

                //UsersandProductsXML(db);


            }
        }
        //Query 04 XML
        private static void UsersandProductsXML(ProductsShopDbContext db)
        {
            var users = db.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    AllProducts = u.ProductsSold.Select(ps => new
                    {
                        ProductName = ps.Name,
                        ProductPrice = ps.Price,

                    })
                })
                .OrderByDescending(u => u.AllProducts.Count())
                .ThenBy(u => u.LastName)
                .ToArray();


            XDocument document = new XDocument();

            document.Add(new XElement("users", new XAttribute("count", $"{users.Length}"))); // root

            foreach (var u in users)
            {


                document.Root.Add(
                    new XElement("user",
                    new XAttribute("first-name", $"{u.FirstName}"),
                    new XAttribute("last-name", $"{u.LastName}"),
                    new XAttribute("age", $"{u.Age}"),
                    new XElement("sold-products", new XAttribute("count", $"{u.AllProducts.Count()}"))
                    ));


                var products = document.Root.Elements()
                    .SingleOrDefault(p => p.Name == "user"
                                          && p.Attribute("first-name").Value == $"{u.FirstName}"
                                          && p.Attribute("last-name").Value == $"{u.LastName}")
                    .Element("sold-products");


                foreach (var prod in u.AllProducts)
                {
                    products.Add(
                        new XElement("product",
                        new XAttribute("name", $"{prod.ProductName}"),
                        new XAttribute("price", $"{prod.ProductPrice}")));
                }

              
            }
            document.Save("XMLExport/UsersandProductsXML.xml");
        }

        //Query 03 XML
        private static void CategoriesByProductsCountXML(ProductsShopDbContext db)
        {
            var categories = db.Categories
                .Select(c => new
                {
                    name = c.Name,
                    numberOfproducts = c.Products.Count,
                    avaragePrice = c.Products.Average(p => p.Product.Price),
                    totalSum = c.Products.Sum(p => p.Product.Price)
                })
                .OrderBy(c => c.numberOfproducts)
                .ToArray();

            XDocument document = new XDocument();

            document.Add(new XElement("categories"));


            foreach (var c in categories)
            {
                document.Root.Add(
                    new XElement("category",
                    new XAttribute("name", c.name),
                    new XElement("products-count", $"{c.numberOfproducts}"),
                    new XElement("average-price", $"{c.avaragePrice}"),
                    new XElement("total-revenue", $"{c.totalSum}")
                   ));
            }
            document.Save("XMLExport/CategoriesByProductsCountXML.xml");
        }

        //Query 02 XML
        private static void SoldProducts(ProductsShopDbContext db)
        {
            var users = db.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(sp => new
                    {
                        productName = sp.Name,
                        productPrice = sp.Price
                    })
                })
                .ToArray();

            XDocument document = new XDocument();

            document.Add(new XElement("users"));

            foreach (var u in users)
            {
                document.Root.Add(
                    new XElement("user",
                    new XAttribute("first-name", $"{u.firstName}"),
                    new XAttribute("last-name", $"{u.lastName}"),
                    new XElement("sold-products")));


                var products = document.Root.Elements()
                    .SingleOrDefault(pe => pe.Name == "user"
                            && pe.Attribute("first-name").Value == $"{u.firstName}"
                            && pe.Attribute("last-name").Value == $"{u.lastName}")
                            .Element("sold-products");



                foreach (var soldProduct in u.SoldProducts)
                {
                    products.Add(
                        new XElement("product",
                        new XElement("name", $"{soldProduct.productName}"),
                        new XElement("price", $"{soldProduct.productPrice}")));
                }
            }

            document.Save("XMLExport/SoldProducts.xml");

        }

        //Query 01 XML
        private static void ProductsInRangeXML(ProductsShopDbContext db)
        {
            var products = db.Products
                .Where(p => p.Price > 1000 && p.Price <= 2000 && p.Buyer != null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToArray();


            var document = new XDocument();

            var root = new XElement("products");

            document.Add(root);

            foreach (var p in products)
            {
                document.Root.Add(
                    new XElement("product",
                        new XAttribute("name", $"{p.name}"),
                        new XAttribute("price", $"{p.price}"),
                        new XAttribute("buyer", $"{p.buyer}")));
            }

            document.Save("XMLExport/ProductsInRangeXML.xml");

        }


        //01 XML
        private static void ImportCategoriesFromXml(ProductsShopDbContext db)
        {
            string xmlString = File.ReadAllText("Files/categories.xml");

            XDocument xmlDocument = XDocument.Parse(xmlString);

            var root = xmlDocument.Root.Elements();

            List<Category> categories = new List<Category>();

            foreach (var cElement in root)
            {
                string name = cElement.Element("name").Value;

                categories.Add(new Category { Name = name });

            }

            db.Categories.AddRange(categories);

            db.SaveChanges();
        }

        //01 XML
        private static void ImportProductsFromXml(ProductsShopDbContext db)
        {
            string xmlString = File.ReadAllText("Files/products.xml");

            XDocument xmDocument = XDocument.Parse(xmlString);

            var root = xmDocument.Root.Elements();

            Random rnd = new Random();

            var userIds = db.Users.Select(u => u.UserId).ToArray();

            List<Product> products = new List<Product>();

            foreach (var p in root)
            {


                string name = p.Element("name").Value;
                decimal price = decimal.Parse(p.Element("price").Value);



                int index = rnd.Next(0, userIds.Length);

                int sellerId = userIds[index];

                int? bayerId = sellerId;

                while (bayerId == sellerId)
                {
                    int bayerIndex = rnd.Next(0, userIds.Length);
                    bayerId = userIds[bayerIndex];

                }
                if (bayerId - sellerId < 5 && bayerId - sellerId > 0)
                {
                    bayerId = null;
                }

                var product = new Product
                {
                    Name = name,
                    Price = price,
                    SellerId = sellerId,
                    BuyerId = bayerId,

                };

                products.Add(product);
            }

            db.Products.AddRange(products);

            db.SaveChanges();


        }

        //01 XML
        private static void ImportUsersFromXml(ProductsShopDbContext db)
        {
            string xmlString = File.ReadAllText("Files/users.xml");

            XDocument xml = XDocument.Parse(xmlString);

            var root = xml.Root.Elements();

            List<User> users = new List<User>();

            foreach (var e in root)
            {
                var firstName = e.Attribute("firstName")?.Value;
                var lastName = e.Attribute("lastName").Value;

                int? age = null;
                if (e.Attribute("age") != null)
                {
                    age = int.Parse(e.Attribute("age").Value);
                }

                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                users.Add(user);
            }

            db.Users.AddRange(users);

            db.SaveChanges();
        }

        //01 Main XML
        private static void ImportDataFromXML(ProductsShopDbContext db)
        {
            ImportUsersFromXml(db);
            ImportProductsFromXml(db);
            ImportCategoriesFromXml(db);
            SetCategories(db);
        }

        //Helper
        private static void ResetDb(ProductsShopDbContext db)
        {
            db.Database.EnsureDeleted();

            db.Database.Migrate();
        }

        //Query 4 Json
        private static void UsersandProducts(ProductsShopDbContext db)
        {

            var users = db.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count,
                        products = u.ProductsSold.Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                    }
                });

            var usersToSerialize = new
            {
                usersCount = users.Count(),
                users
            };


            var jsonString = JsonConvert.SerializeObject(usersToSerialize, Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            File.WriteAllText("JsonExport/usersandproducts.json", jsonString);


        }

        //Query 3 Json
        private static void CategoriesByProductsCount(ProductsShopDbContext db)
        {
            var categories = db.Categories.Select(c => new
            {

                category = c.Name,
                productsCount = c.Products.Count,
                averagePrice = c.Products.Average(cp => cp.Product.Price),
                totalRevenue = c.Products.Sum(cp => cp.Product.Price)

            })
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("JsonExport/categoriesbyproductscount.json", jsonString);

        }


        //Query 2 Json
        private static void SuccessfullySoldProducts(ProductsShopDbContext db)
        {
            var users = db.Users.Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLasName = ps.Buyer.LastName

                    })
                })
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,  // optional
                NullValueHandling = NullValueHandling.Ignore // optional
            });

            File.WriteAllText("JsonExport/successfullysoldproducts.json", jsonString);

        }


        //Query 1 Json
        private static void ProductsInRange(ProductsShopDbContext db)
        {

            var products = db.Products
                .Where(p => p.Price > 500 && p.Price <= 1000)
                .OrderBy(pr => pr.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seler = p.Seller.FirstName + " " + p.Seller.LastName


                })
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(products, Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore // optional
                });

            File.WriteAllText("JsonExport/productsinrange.json", jsonString);

        }


        //01 Json
        private static void SetCategories(ProductsShopDbContext db)
        {
            var productIds = db.Products.Select(p => p.ProductId).ToArray();
            var categoryIds = db.Categories.Select(c => c.CategoryId).ToArray();

            Random rnd = new Random();

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var p in productIds)
            {


                for (int i = 0; i < 3; i++)
                {

                    int index = rnd.Next(0, categoryIds.Length);
                    while (categoryProducts.Any(c => c.ProductId == p && c.CategoryId == categoryIds[index]))
                    {
                        index = rnd.Next(0, categoryIds.Length);
                    }

                    CategoryProduct cp = new CategoryProduct
                    {
                        ProductId = p,
                        CategoryId = categoryIds[index]
                    };
                    categoryProducts.Add(cp);

                }

            }

            db.CategoryProducts.AddRange(categoryProducts);
            db.SaveChanges();
        }

        //01 Json
        private static void ImportProducts(ProductsShopDbContext db)
        {
            string jsonToString = File.ReadAllText("Files/products.json");

            Product[] products = JsonConvert.DeserializeObject<Product[]>(jsonToString);

            Random rnd = new Random();

            int[] userIds = db.Users.Select(x => x.UserId).ToArray();


            foreach (var p in products)
            {
                int index = rnd.Next(0, userIds.Length);

                int sellerId = userIds[index];

                int? bayerId = sellerId;

                while (bayerId == sellerId)
                {
                    int bayerIndex = rnd.Next(0, userIds.Length);
                    bayerId = userIds[bayerIndex];

                }
                if (bayerId - sellerId < 5 && bayerId - sellerId > 0)
                {
                    bayerId = null;
                }

                p.SellerId = sellerId;
                p.BuyerId = bayerId;
            }



            db.Products.AddRange(products);

            db.SaveChanges();
        }

        //01 Json
        private static void ImportCategories(ProductsShopDbContext db)
        {


            string jsonToString = File.ReadAllText("Files/categories.json");

            Category[] categories = JsonConvert.DeserializeObject<Category[]>(jsonToString);

            db.Categories.AddRange(categories);

            db.SaveChanges();
        }

        //01 Main Json
        private static void ImportData(ProductsShopDbContext dbContext)
        {


            ImportUsers(dbContext);
            ImportProducts(dbContext);
            ImportCategories(dbContext);
            SetCategories(dbContext);

        }

        //01 Json
        private static void ImportUsers(ProductsShopDbContext dbContext)
        {
            string path = "Files/users.json";

            string jsonString = File.ReadAllText(path);


            User[] users = JsonConvert.DeserializeObject<User[]>(jsonString);


            dbContext.Users.AddRange(users);

            dbContext.SaveChanges();
        }
    }
}
