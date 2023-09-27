namespace CarDealer.Data.Profiles;

using AutoMapper;
using DTOs.Import;
using Models;

public class SupplierProfile : Profile
{
    public SupplierProfile()
    {
        CreateMap<SupplierDto, Supplier>();
    }
}