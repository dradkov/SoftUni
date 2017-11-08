    SoftUniContext db = new SoftUniContext()
    
          using (db)
          {
              var result = db.Employees
                  .Where(e => e.Salary > 50000)
                  .Select(e => new
                         {
                            Name = e.FirstName
                         })
                 .OrderBy(e => e.Name)
                 .ToList()
              foreach (var employee in result)
              {
                  Console.WriteLine(employee.Name);
              }
	     	 }
