using System;
using System.Collections.Generic;
using Employee.DTO;

namespace Employee.Models
{
    public class Employee
    {
        public int EmpoyeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        public int? ManagerId { get; set; }

    }
}
