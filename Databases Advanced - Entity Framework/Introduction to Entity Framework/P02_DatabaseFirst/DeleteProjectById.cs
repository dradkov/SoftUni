SoftUniContext db = new SoftUniContext();

            using (db)
            {

                var projectId = db.Projects.Find(2);

                var empProjects = db.EmployeesProjects.Where(p => p.ProjectId == 2);

                foreach (var ep in empProjects)
                {
                    db.EmployeesProjects.Remove(ep);
                }

                db.Projects.Remove(projectId);

                db.SaveChanges();

                var projects = db.Projects.Take(10).ToList();

                foreach (var pro in projects)
                {
                    Console.WriteLine(pro.Name);
                }
				
			}
