namespace ProductShop.Data.Profiles;

using AutoMapper;
using DTOs.Import;
using Models;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}