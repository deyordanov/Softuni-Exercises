namespace CarDealer.Data.ExportProfiles;

using AutoMapper;
using DTOs.Export;
using Models;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.BirthDate,
                opt => opt.MapFrom(src => src.BirthDate.ToString("dd/MM/yyyy")));
    }
}