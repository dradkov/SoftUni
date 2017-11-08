SoftUniContext db = new SoftUniContext();

            using (db)
            {
                Employee employee = db.Employees.First(n => n.LastName == "Nakov");

                Address adress = new Address
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                employee.Address = adress;
                db.SaveChanges();

                var employeeAdreses = db.Employees
                    .Select
                         (e => new
                         {
                             Addres =  e.Address.AddressText,
                             Id = e.AddressId
                         })
                    .OrderByDescending(a=>a.Id)
                    .Take(10)
                    .ToList();


                foreach (var address in employeeAdreses)
                {
                    Console.WriteLine(address.Addres);
                }

            }
