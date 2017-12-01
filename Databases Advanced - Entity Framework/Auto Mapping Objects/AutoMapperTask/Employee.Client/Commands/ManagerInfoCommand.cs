using System.Text;

namespace Employee.Client.Commands
{
    using System;
    using Employee.Client.Contracts;
    using Employee.Services;

    public class ManagerInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public ManagerInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var employee = employeeService.ManagerInfo(employeeId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} | Employees: {employee.EmployeeDtos.Count}");

            foreach (var dtos in employee.EmployeeDtos)
            {
                sb.AppendLine($"  - {dtos.FirstName} {dtos.LastName} - ${dtos.Salary}");
            }

            return sb.ToString().Trim();
        }
    }
}
