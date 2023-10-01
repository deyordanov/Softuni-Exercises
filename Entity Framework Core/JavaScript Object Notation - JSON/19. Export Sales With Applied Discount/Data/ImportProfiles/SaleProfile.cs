namespace CarDealer.Data.Profiles;

using AutoMapper;
using DTOs.Import;
using Models;

public class SaleProfile : Profile
{
    public SaleProfile()
    {
        CreateMap<SaleDto, Sale>();
    }
}