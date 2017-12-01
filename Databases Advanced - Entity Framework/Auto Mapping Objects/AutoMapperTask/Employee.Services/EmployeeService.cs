using System.Collections.Generic;
using System.Linq;

namespace Employee.Services
{
    using System;
    using Employee.Data;
    using Employee.DTO;
    using AutoMapper;
    using Employee.Models;

    public class EmployeeService
    {
        private readonly AutoMapeprDBContext context;



        public EmployeeService(AutoMapeprDBContext context)
        {
            this.context = context;
       
        }

        public EmployeeDto ById(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;

        }

        public void AddEmployee(EmployeeDto dto)
        {
            var employee = Mapper.Map<Employee>(dto);

            context.Employees.Add(employee);

            context.SaveChanges();

        }

        public string SetBirthday(int emoloyeeId, DateTime date)
        {
            var employee = context.Employees.Find(emoloyeeId);

            employee.Birthday = date;

            context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public string SetAddress(int emoloyeeId,string address)
        {
            var employee = context.Employees.Find(emoloyeeId);

            employee.Address = address;

            context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }
        public EmployeePersonalDto PersonalDto(int emoloyeeId)
        {
            var employee = context.Employees.Find(emoloyeeId);

            var personalDto = Mapper.Map<EmployeePersonalDto>(employee);

            return personalDto;

        }

        public void SetManager(int emoloyeeId, int managerId)
        {
            var employee = context.Employees.Find(emoloyeeId);
            var managerEmp = context.Employees.Find(managerId);

            var empoyeeDto = new EmployeeDto(employee.FirstName,employee.LastName,employee.Salary);

            ManagerDTO manager = Mapper.Map<ManagerDTO>(managerEmp);

            employee.ManagerId = managerId;

            manager.EmployeeDtos.Add(empoyeeDto);


            context.SaveChanges();
        }

        public ManagerDTO ManagerInfo(int emoloyeeId)
        {
            var employee = context.Employees.Find(emoloyeeId);

            ManagerDTO manager = Mapper.Map<ManagerDTO>(employee);

            return manager;
        }

        public List<EmployeeDto> ListEmployees(int age)
        {
            return null;
        }

    }
}
