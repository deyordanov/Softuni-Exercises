namespace ProductShop.Data.Profiles;

using AutoMapper;
using DTOs.Import;
using Models;

public class CategoryProductProfile : Profile
{
    public CategoryProductProfile()
    {
        CreateMap<CategoryProduct, CategoryProductDto>().ReverseMap();
    }
}