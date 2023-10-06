namespace CarDealer.Data.ExportProfiles;

using AutoMapper;
using DTOs.Export;
using Models;

public class SupplierProfile : Profile
{
    public SupplierProfile()
    {
        CreateMap<Supplier, SupplierDto>()
            .ForMember(dest => dest.PartsCount,
                opt => opt.MapFrom(src => src.Parts.Count));
    }
}