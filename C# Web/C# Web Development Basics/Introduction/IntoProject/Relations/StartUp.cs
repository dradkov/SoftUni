namespace Relations
{
    using System;
    using System.Linq;
    using Relations.Data;
    using Relations.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (AppDbContext db = new AppDbContext())
            {
                SetDb(db);
                FillDbWithSalesmans(db);
                ItemsInfo(db);
                CommandExecution(db);
                //PrintShopHierarchy(db);
                //PrintShopHierarchyExtended(db);
                //PrintShopHierarchyComplexQuery(db);
                //PrintExplicitDataLoading(db);
                //PrintQueryLoadedData(db);
            }
        }

      
        private static void SetDb(AppDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        private static void FillDbWithSalesmans(AppDbContext db)
        {
            string[] info = Console.ReadLine().Split(';');

            foreach (var salesman in info)
            {
                db.Add(new Salesman()
                {
                    Name = salesman
                });
            }
            db.SaveChanges();
        }

        private static void CommandExecution(AppDbContext db)
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {

                string[] tokens = input.Split('-');

                string cmd = tokens[0];
                string info = tokens[1];

                switch (cmd)
                {
                    case "register": RegisterData(db, info); break;
                    case "order": OrderFunctionality(db, info); break;
                    case "review": ReviewFunctionality(db, info); break;
                    default:
                        break;
                }

            }

        }

        private static void RegisterData(AppDbContext db, string info)
        {

            string[] tokens = info.Split(';');
            string customerName = tokens[0];
            int salesmanId = int.Parse(tokens[1]);

            Customer customer = new Customer()
            {
                Name = customerName
            };

            db.Add(customer);

            Salesman salesman = db.Salesmann.Find(salesmanId);

            salesman.Customers.Add(customer);

            db.SaveChanges();
        }

        private static void OrderFunctionality(AppDbContext db, string info)
        {

            string[] tokens = info.Split(';');

            int custumerId = int.Parse(tokens[0]);

            Order order = new Order()
            {
                CustomerId = custumerId
            };

            for (int i = 1; i < tokens.Length; i++)
            {

                int itemId = int.Parse(tokens[i]);

                order.Items.Add(new ItemOrder()
                {
                    ItemId = itemId
                });
            }
            db.Add(order);

            db.SaveChanges();
        }

        private static void ReviewFunctionality(AppDbContext db, string info)
        {
            string[] tokens = info.Split(';');

            int custumerId = int.Parse(tokens[0]);
            int itemId = int.Parse(tokens[1]);

            db.Add(new Review()
            {
                CustomerId = custumerId,
                ItemId = itemId
            });

            db.SaveChanges();
        }

        private static void ItemsInfo(AppDbContext db)
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {

                string[] tokens = input.Split(';');

                db.Add(new Item()
                {
                    Name = tokens[0],
                    Price = decimal.Parse(tokens[1])

                });
            }
            db.SaveChanges();
        }

        private static void PrintShopHierarchy(AppDbContext db)
        {
            var salesman = db.Salesmann.Select(s => new
            {
                s.Name,
                Customers = s.Customers.Count
            })
                .OrderByDescending(c => c.Customers)
                .ThenBy(c => c.Name)
                .ToArray();

            foreach (var sm in salesman)
            {
                Console.WriteLine($"{sm.Name} - {sm.Customers} customers");
            }
        }

        private static void PrintShopHierarchyExtended(AppDbContext db)
        {

            var customers = db.Customers.Select(c => new
            {
                c.Name,
                Order = c.Orders.Count,
                Review = c.Reviews.Count

            })
                .OrderByDescending(o => o.Order)
                .ThenByDescending(r => r.Review)
                .ToArray();

            foreach (var cr in customers)
            {
                Console.WriteLine($"{cr.Name}");
                Console.WriteLine($"Orders: {cr.Order}");
                Console.WriteLine($"Reviews: {cr.Review}");
            }

        }

        private static void PrintShopHierarchyComplexQuery(AppDbContext db)
        {

            int customerId = int.Parse(Console.ReadLine());

            var customer = db.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    Orders = c.Orders.Select(o => new
                        {
                            OrderId = o.Id,
                            ItemsCount = o.Items.Count
                        })
                        .OrderBy(o => o.OrderId),

                    Reviews = c.Reviews.Count
                })
                .FirstOrDefault();

            foreach (var order in customer.Orders)
            {
                Console.WriteLine($"order {order.OrderId}: {order.ItemsCount} items");
            }
            Console.WriteLine($"reviews: {customer.Reviews}");

        }

        private static void PrintExplicitDataLoading(AppDbContext db)
        {
            int customerId = int.Parse(Console.ReadLine());

            var customer = db.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count,
                    Salesman = c.Salesman.Name
                }).FirstOrDefault();

            Console.WriteLine($"Customer: {customer.Name}");
            Console.WriteLine($"Orders count:{customer.Orders}");
            Console.WriteLine($"Reviews count: {customer.Reviews}");
            Console.WriteLine($"Salesman: {customer.Salesman}");

        }

        private static void PrintQueryLoadedData(AppDbContext db)
        {
            int customerId = int.Parse(Console.ReadLine());

            var customer = db.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    Orders = c.Orders.Count(i => i.Items.Count > 1)

                }).FirstOrDefault();

            Console.WriteLine($"Orders: {customer.Orders}");
        }

       
    }
}
