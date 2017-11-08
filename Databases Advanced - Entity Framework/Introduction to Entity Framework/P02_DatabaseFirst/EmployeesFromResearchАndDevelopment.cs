  SoftUniContext db = new SoftUniContext();

            using (db)
            {

                var result = db.Employees
                    .Include(d => d.Department)
                    .Where(e => e.Department.Name == "Research and Development")
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Department = e.Department.Name,
                        Salary = e.Salary
                    })
                    .OrderBy(x => x.Salary)
                    .ThenByDescending(x => x.FirstName)
                    .ToList();

                foreach (var emp in result)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} from {emp.Department} - ${emp.Salary:f2}");
                }

            }	
