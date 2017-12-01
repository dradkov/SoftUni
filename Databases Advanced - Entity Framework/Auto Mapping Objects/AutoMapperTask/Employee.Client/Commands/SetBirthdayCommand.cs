using System;
using System.Collections.Generic;
using System.Text;
using Employee.Client.Contracts;
using Employee.DTO;
using Employee.Services;

namespace Employee.Client.Commands
{
    public class SetBirthdayCommand : ICommand
    {

        private readonly EmployeeService employeeService;

        public SetBirthdayCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            DateTime date = DateTime.ParseExact(args[1], "dd-MM-yyyy", null);

          
            
            var employeeName = employeeService.SetBirthday(employeeId, date);

            return $"{employeeName}'s birthday was set correctly ";
        }
    }
}
