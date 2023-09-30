using AutoMapper;
using ManageEmployees.API.Models.Entities;

namespace ManageEmployees.API.Dtos.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, AddEmployee>().ReverseMap();
            //.ForMember(dest => dest.Department, opt => opt.MapFrom(e => e.Department.Id)).ReverseMap();
            //.ForMember(dest => dest.Contracts, opt => opt.MapFrom(e => e.Contracts.Select(c => c.Name).ToList())).ReverseMap();

            CreateMap<Department, AddDepartment>().ReverseMap();
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(e => e.Employees.Select(e => $"{e.FirstName} {e.LastName}"))).ReverseMap();

            //Contract
            CreateMap<AddContract, Contract>().ReverseMap();
            CreateMap<Contract, ContractDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(e => e.Employee.FirstName + " " + e.Employee.LastName)).ReverseMap();

        }
    }
}
