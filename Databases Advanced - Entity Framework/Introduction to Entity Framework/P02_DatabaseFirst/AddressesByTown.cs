SoftUniContext db = new SoftUniContext();

            using (db)
            {

                var adres = db.Addresses
                    .Include(e => e.Employees)
                    .Include(t => t.Town)
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(t => t.Town.Name)
                    .Take(10)
                    .ToList();

                foreach (var adrs in adres)
                {

                    Console.WriteLine($"{adrs.AddressText}, {adrs.Town.Name} - {adrs.Employees.Count} employees");
                }
		    	} 
