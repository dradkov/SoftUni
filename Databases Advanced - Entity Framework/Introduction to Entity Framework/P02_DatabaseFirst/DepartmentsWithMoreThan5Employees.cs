SoftUniContext db = new SoftUniContext();

            using (db)
            {
                var result = db.Departments
                    .Include(s => s.Employees)
                    .Where(s => s.Employees.Count > 5)
                    .OrderBy(p => p.Employees.Count)
                    .ThenBy(x => x.Name)
                    .ToList();


                foreach (var depart in result)
                {
                    Console.WriteLine($"{depart.Name} – {depart.Manager.FirstName} {depart.Manager.LastName}");

                    foreach (var emp in depart.Employees.OrderBy(x=>x.FirstName).ThenBy(x=>x.LastName))
                    {
                        Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                    }

                    Console.WriteLine("----------");
                }



            }
