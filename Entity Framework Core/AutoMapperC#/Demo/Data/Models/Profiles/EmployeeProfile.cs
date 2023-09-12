namespace Demo.Data.Models.Profiles;

using AutoMapper;
using Resolvers;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom<FullNameResolver>())
            .ReverseMap()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom<FirstNameResolver>())
            .ForMember(dest => dest.LastName, opt => opt.MapFrom<LastNameResolver>());
    }
}