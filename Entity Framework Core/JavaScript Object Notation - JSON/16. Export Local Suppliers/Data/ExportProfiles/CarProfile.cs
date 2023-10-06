namespace CarDealer.Data.ExportProfiles;

using AutoMapper;
using DTOs.Export;
using Models;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarDto>()
            .ForMember(dest => dest.TraveledDistance,
                opt => opt.MapFrom(src => src.TravelledDistance));
    }
}