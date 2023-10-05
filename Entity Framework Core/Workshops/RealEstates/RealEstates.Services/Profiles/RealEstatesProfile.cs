namespace RealEstates.Services.Profiles;

using AutoMapper;
using Models;
using RealEstates.Models;

public class RealEstatesProfile : Profile
{
    public RealEstatesProfile()
    {
        this.CreateMap<District, DistrictDataDto>()
            .ForMember(d => d.PropertiesCount,
                o => o.MapFrom(s => s.Properties.Count))
            .ForMember(d => d.AveragePricePerSquareMeter,
                o => o.MapFrom(s => s.Properties
                    .Where(p => p.Price.HasValue)
                    .Average(p => p.Price.Value / (decimal)p.Size)));

        this.CreateMap<Property, PropertyDataDto>()
            .ForMember(d => d.Price,
                o => o.MapFrom(s => s.Price ?? 0))
            .ForMember(d => d.BuildingType,
                o => o.MapFrom(s => s.BuildingType.Name))
            .ForMember(d => d.PropertyType,
                o => o.MapFrom(s => s.PropertyType.Name));

        this.CreateMap<Property, PropertyFullDataDto>()
            .ForMember(d => d.Tags,
                o => o.MapFrom(s => s.Tags.Select(t => new TagDataDto()
                {
                    Name = t.Name,
                })))
            .ForMember(d => d.Price,
                o => o.MapFrom(s => s.Price ?? 0))
            .ForMember(d => d.BuildingType,
                o => o.MapFrom(s => s.BuildingType.Name))
            .ForMember(d => d.PropertyType,
                o => o.MapFrom(s => s.PropertyType.Name));
    }
}