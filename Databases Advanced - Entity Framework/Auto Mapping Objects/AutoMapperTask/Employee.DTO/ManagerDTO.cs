namespace Employee.DTO
{
    using System.Collections.Generic;

    public class ManagerDTO
    {

        public string  FirstName { get; set; }

        public string  LastName { get; set; }

        public ICollection<EmployeeDto> EmployeeDtos { get; set; } = new List<EmployeeDto>();
    }
}
