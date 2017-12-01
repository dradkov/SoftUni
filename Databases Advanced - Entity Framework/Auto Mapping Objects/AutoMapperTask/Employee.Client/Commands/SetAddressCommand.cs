using Employee.Client.Contracts;
using Employee.Services;

namespace Employee.Client.Commands
{
   public class SetAddressCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetAddressCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            string address = args[1];

            var employeeName = employeeService.SetAddress(employeeId, address);

            return $"{employeeName}'s addres was set correctly ";
        }
    }
}
