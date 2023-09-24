namespace ProductShop.Data.Profiles;

using AutoMapper;
using DTOs.Export;
using Models;

public class CategoriesByCountProfile : Profile
{
    public CategoriesByCountProfile()
    {
        CreateMap<Category, CategoriesByCountDto>()
            .ForMember(dest => dest.ProductsCount,
                opt => opt.MapFrom(x => x.CategoriesProducts.Count))
            .ForMember(dest => dest.AverageProductPrice, 
                opt => opt.MapFrom(x => x.CategoriesProducts.Average(p => p.Product.Price).ToString("F2")))
            .ForMember(dest => dest.TotalRevenue,
                opt => opt.MapFrom(x => x.CategoriesProducts.Sum(p => p.Product.Price).ToString("F2")));
    }
    
}