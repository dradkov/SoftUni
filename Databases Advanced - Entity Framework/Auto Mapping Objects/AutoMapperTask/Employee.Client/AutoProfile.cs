namespace Employee.Client
{
    using AutoMapper;
    using Employee.Models;
    using Employee.DTO;

    public  class AutoProfile : Profile
    {
        public AutoProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<Employee, EmployeePersonalDto>();
            CreateMap<EmployeePersonalDto, Employee>();

            CreateMap<Employee, ManagerDTO>();
            CreateMap<ManagerDTO,Employee >();

        }
    }
}
