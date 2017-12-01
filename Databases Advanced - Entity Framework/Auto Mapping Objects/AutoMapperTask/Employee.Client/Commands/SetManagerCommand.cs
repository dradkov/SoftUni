namespace Employee.Client.Commands
{
    using System;
    using Employee.Client.Contracts;
    using Employee.Services;

    public class SetManagerCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetManagerCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            employeeService.SetManager(employeeId,managerId);

            return "Command  was successfully set";
        }
    }
}
