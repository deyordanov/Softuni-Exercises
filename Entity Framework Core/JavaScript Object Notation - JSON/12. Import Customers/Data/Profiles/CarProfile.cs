namespace CarDealer.Data.Profiles;

using AutoMapper;
using DTOs.Import;
using Models;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<CarDto, Car>()
            .ForMember(dest => dest.PartsCars,
                opt => opt.MapFrom(src => src.PartsId.ToHashSet().Select(pi => new PartCar()
                {
                    PartId = pi
                })));
    }
}