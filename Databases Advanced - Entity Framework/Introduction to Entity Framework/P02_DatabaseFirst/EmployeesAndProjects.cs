SoftUniContext db = new SoftUniContext();

            using (db)
            {

                var employeesAndProjects = db.Employees
                    .Include(ep => ep.EmployeesProjects)
                    .ThenInclude(p => p.Project)
                    .Where(p => p.EmployeesProjects
                        .Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                    .Take(30)
                    .ToList();


                foreach (var employee in employeesAndProjects)
                {
                    
                    string EmployeeName = employee.FirstName + " " + employee.LastName;

                    Employee manager = db.Employees.Find(employee.ManagerId);

                    Console.WriteLine($"{EmployeeName} – Manager: {manager.FirstName} {manager.LastName}");

                    foreach (var pro in employee.EmployeesProjects)
                    {                      
                        string startDate = pro.Project.StartDate.ToString();

                        string endDate = pro.Project.EndDate.ToString();

                        if (string.IsNullOrEmpty(endDate))
                        {
                            Console.WriteLine($"--{pro.Project.Name} - {startDate} - not finished");
                        }
                        else
                        {
                            Console.WriteLine($"--{pro.Project.Name} - {startDate} - {endDate}");
                        }                      
                    }
                }
            }
