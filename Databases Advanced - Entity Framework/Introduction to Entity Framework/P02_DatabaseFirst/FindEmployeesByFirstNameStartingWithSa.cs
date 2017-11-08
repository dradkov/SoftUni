SoftUniContext db = new SoftUniContext();

            using (db)
            {

                var employees = db.Employees
                    .Where(e => e.FirstName.StartsWith("Sa"))
                    .Select(e => new
                    {
                        EmployeeName = e.FirstName + " " + e.LastName,
                        JobTitle = e.JobTitle,
                        Salary = e.Salary
                    })
                    .OrderBy(e=>e.EmployeeName)
                    .ToList();


                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.EmployeeName} - {emp.JobTitle} - (${emp.Salary:F2})");
                }
            }
