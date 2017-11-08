public class StartUp
    {
        public static void Main()
        {
            var db = new SoftUniContext();

            using (db)
            {
                List<Employee> allEmployees = db.Employees
                .OrderBy(e => e.EmployeeId)
                .ToList();

                foreach (var em in allEmployees)
                {
                    Console.WriteLine($"{em.FirstName} {em.LastName} {em.MiddleName} {em.JobTitle} {em.Salary:f2}");
                }
            }
        }

    }
