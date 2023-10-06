namespace CarDealer.Data.ExportProfiles;

using AutoMapper;
using DTOs.Export;
using Models;

public class PartsProfile : Profile
{
    public PartsProfile()
    {
        CreateMap<Car, PartsWrapperDto>()
            .ForMember(dest => dest.Car,
                opt => opt.MapFrom(src => new PartsCarDto()
                {
                    Make = src.Make,
                    Model = src.Model,
                    TraveledDistance = src.TraveledDistance,
                }))
            .ForMember(dest => dest.Parts,
                opt => opt.MapFrom(src => src.PartsCars.Select(p => new PartsPartDto()
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price.ToString("F2"),
                })));
    }
}