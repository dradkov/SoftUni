using System;

namespace Employee.DTO
{
    public class EmployeePersonalDto
    {
        public int EmpoyeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }
    }
}
