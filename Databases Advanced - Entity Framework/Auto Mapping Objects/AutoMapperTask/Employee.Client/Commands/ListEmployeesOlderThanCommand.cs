using System;
using System.Collections.Generic;
using System.Text;
using Employee.Client.Contracts;
using Employee.Services;

namespace Employee.Client.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public ListEmployeesOlderThanCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        public string Execute(params string[] args)
        {

            int age = int.Parse(args[0]);

            var list = employeeService.ListEmployees(age);


            return list.ToString();
        }
    }
}
