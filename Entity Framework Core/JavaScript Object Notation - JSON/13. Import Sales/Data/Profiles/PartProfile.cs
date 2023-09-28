namespace CarDealer.Data.Profiles;

using AutoMapper;
using DTOs.Import;
using Models;

public class PartProfile : Profile
{
    public PartProfile()
    {
        CreateMap<PartDto, Part>();
    }
}