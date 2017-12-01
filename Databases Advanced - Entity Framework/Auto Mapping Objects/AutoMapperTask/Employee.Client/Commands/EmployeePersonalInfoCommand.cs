using System.Text;

namespace Employee.Client.Commands
{
    using System;
    using Employee.Client.Contracts;
    using Employee.Services;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeePersonalInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

          var employee =   employeeService.PersonalDto(employeeId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {employee.EmpoyeeId} - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}");
            sb.AppendLine($"Birthday: {employee.Birthday}");
            sb.AppendLine($"Address: {employee.Address}");

            return sb.ToString().Trim();

        }
    }
}
