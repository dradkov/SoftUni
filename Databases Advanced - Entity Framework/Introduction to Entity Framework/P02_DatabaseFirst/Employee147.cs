SoftUniContext db = new SoftUniContext();

            using (db)
            {

                Employee employee = db.Employees
                    .Include(ep => ep.EmployeesProjects)
                    .ThenInclude(p => p.Project)                   
                    .First(x => x.EmployeeId == 147);
                    

                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                foreach (var pro in employee.EmployeesProjects.OrderBy(x=>x.Project.Name))
                {
                    Console.WriteLine($"{pro.Project.Name}");
                }
            }
