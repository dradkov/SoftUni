using System;
using System.Collections.Generic;
using System.Text;
using Employee.Client.Contracts;
using Employee.Services;

namespace Employee.Client.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeeInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            var EmployeeDto = employeeService.ById(int.Parse(args[0]));

            return $"ID: {EmployeeDto.EmpoyeeId} - {EmployeeDto.FirstName} {EmployeeDto.LastName} -  ${EmployeeDto.Salary:f2}";
        }
    }
}
