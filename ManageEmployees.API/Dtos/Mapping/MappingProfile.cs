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
        }
    }
}
