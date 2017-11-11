using System;

namespace P03_SalesDatabase
{
    using System.ComponentModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query.Expressions;
    using P03_SalesDatabase.Data;
    using P03_SalesDatabase.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SalesContext db = new SalesContext();


            using (db)
            {
                ResetDataBase(db); // Test DataBase
            }

        }

        private static void ResetDataBase(SalesContext db)
        {
            db.Database.EnsureDeleted();

            db.Database.Migrate();

            Seed(db);
        }

        private static void Seed(SalesContext db)
        {

            Customer customer = new Customer
            {
                Name = "Gosho",
                Email = "dim@abv.bg",
                CreditCardNumber = "123",

            };


            Customer customer2 = new Customer
            {
                Name = "Ivan",
                Email = "ivam@gmail.bg",
                CreditCardNumber = "567",

            };

            db.Add(customer2);

            db.Add(customer);




            Sale sale = new Sale
            {
                Date = DateTime.Now,
                ProductId = 1,
                CustomerId = 1,
                StoreId = 2,

            };

            db.AddRange(sale);



            Sale sale2 = new Sale
            {
                Date = DateTime.Now,
                ProductId = 2,
                CustomerId = 2,
                StoreId = 1,

            };
            db.Add(sale2);

            Sale sale3 = new Sale
            {
                Date = DateTime.Now,
                ProductId = 1,
                CustomerId = 1,
                StoreId = 2,

            };
            db.Add(sale3);

            Product product = new Product
            {
                Name = "Sirene",
                Quantity = 15,
                Price = 120,
                Description = "Unikalno",

            };

            product.Sales.Add(sale);
            product.Sales.Add(sale2);



            Product product2 = new Product
            {
                Name = "Salam",
                Quantity = 5,
                Price = 13,
                Description = "Vkusno",

            };
            product2.Sales.Add(sale);
            product2.Sales.Add(sale2);

            db.Add(product2);

            Store store = new Store
            {
                Name = "Metro"

            };
            store.Sales.Add(sale3);



            db.Add(store);
            db.SaveChanges();

        }
    }
}
