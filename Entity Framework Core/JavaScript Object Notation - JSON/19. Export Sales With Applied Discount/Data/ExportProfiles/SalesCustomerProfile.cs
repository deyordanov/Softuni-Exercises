namespace CarDealer.Data.ExportProfiles;

using AutoMapper;
using DTOs.Export;
using Models;

public class SalesCustomerProfile : Profile
{
    public SalesCustomerProfile()
    {
        CreateMap<Customer, SalesCustomerDto>()
            .ForMember(dest => dest.CarsBought,
                opt => opt.MapFrom(src => src.Sales.Count))
            .ForMember(dest => dest.PartsPrice,
                opt => opt.MapFrom(src => src.Sales.Select(s => s.Car.PartsCars.Sum(p => p.Part.Price))));
    }
}