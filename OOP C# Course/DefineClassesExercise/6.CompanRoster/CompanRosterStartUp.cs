using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanRoster
{

    public class CompanRosterStartUp
    {
        static void Main(string[] args)
        {
            var numLines = int.Parse(Console.ReadLine());

            var worker = new List<Employee>();

            for (int i = 0; i < numLines; i++)
            {
                var splitLine = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                var name = splitLine[0];
                decimal salary = decimal.Parse(splitLine[1]);
                var position = splitLine[2];
                var department = splitLine[3];
                var email = string.Empty;
                var age = 0;
                if (splitLine.Length == 5)
                {
                    if (splitLine[4].Contains("@"))
                    {
                        email = splitLine[4];
                        age = -1;

                    }
                    else
                    {
                        age = int.Parse(splitLine[4]);
                        email = "n/a";
                    }

                }
                else if (splitLine.Length == 4)
                {
                    age = -1;
                    email = "n/a";
                }
                else if (splitLine.Length > 5)
                {
                    email = splitLine[4];
                    age = int.Parse(splitLine[5]);
                }

                worker.Add(new Employee(name, salary, position, department, email, age));
            }

            var result = worker
                 .GroupBy(x => x.Department)
                 .Select(x => new
                 {
                     Department = x.Key,
                     AvaregeSalary = x.Average(e => e.Salary),
                     Employees = x.OrderByDescending(e => e.Salary)
                 })
                 .OrderByDescending(x => x.AvaregeSalary)
                 .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Department}");


            foreach (var workers in result.Employees)
            {
                Console.WriteLine($"{workers.Name} {workers.Salary:F2} {workers.Email} {workers.Age}");
            }
        }
    }
}
