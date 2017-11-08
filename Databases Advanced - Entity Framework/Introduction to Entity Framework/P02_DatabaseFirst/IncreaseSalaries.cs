SoftUniContext db = new SoftUniContext();

            using (db)
            {

                var employees = db.Employees
                    .Include(d => d.Department)
                    .Where(d => d.Department.Name == "Engineering" ||
                                d.Department.Name == "Tool Design" ||
                                d.Department.Name == "Marketing" ||
                                d.Department.Name == "Information Services"
                    )
                    .Select(e => new
                    {
                        EmployeeName = e.FirstName + " " + e.LastName,
                        Salare = e.Salary + ((12 * e.Salary) / 100)
                    })
                   .ToList();

                foreach (var emp in employees.OrderBy(c=>c.EmployeeName))
                {
                    Console.WriteLine($"{emp.EmployeeName} (${emp.Salare:f2})");
                }    

            }
