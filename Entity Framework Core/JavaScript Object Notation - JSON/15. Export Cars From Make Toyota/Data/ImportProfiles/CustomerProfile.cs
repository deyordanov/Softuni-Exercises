namespace CarDealer.Data.Profiles;

using AutoMapper;
using DTOs.Import;
using Models;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerDto, Customer>();
    }
}