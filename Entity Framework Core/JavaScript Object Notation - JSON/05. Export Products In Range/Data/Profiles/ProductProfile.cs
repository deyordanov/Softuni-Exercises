namespace ProductShop.Data.Profiles;

using AutoMapper;
using DTOs.Import;
using Models;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}