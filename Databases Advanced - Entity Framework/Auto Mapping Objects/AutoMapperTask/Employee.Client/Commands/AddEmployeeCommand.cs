using Employee.Client.Contracts;
using Employee.DTO;
using Employee.Services;

namespace Employee.Client.Commands
{
   public class AddEmployeeCommand: ICommand
   {
       private readonly EmployeeService employeeService;

       public AddEmployeeCommand(EmployeeService employeeService)
       {
           this.employeeService = employeeService;
       }

        public string Execute(params string[] args)
        {
            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            EmployeeDto employeeDto = new EmployeeDto(firstName,lastName,salary);

            employeeService.AddEmployee(employeeDto);


            return $"Employee {firstName} {lastName} with Salary {salary} was successfully added";
        }
    }
}
