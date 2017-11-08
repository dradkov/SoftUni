SoftUniContext db = new SoftUniContext();

            using (db)
            {
                var result = db.Projects
                    .OrderByDescending(x => x.StartDate)
                    .Take(10)
                    .ToList();


                var orderedProjects = result.OrderBy(x => x.Name)
                    .ThenBy(p => p.Description)
                    .ThenBy(p => p.StartDate)
                    .ToList();

                foreach (var pro in orderedProjects)
                {
                    Console.WriteLine(pro.Name);

                    Console.WriteLine(pro.Description);

                    Console.WriteLine(pro.StartDate);
                }
