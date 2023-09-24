namespace ProductShop.Data.Profiles;

using AutoMapper;
using DTOs.Export;
using Models;

public class ProductInRangeProfile : Profile
{
    public ProductInRangeProfile()
    {
        CreateMap<Product, ProductsInRangeDto>()
            .ForMember(dest => dest.ProductName,
                opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.ProductPrice, 
                opt => opt.MapFrom(x => x.Price))
            .ForMember(dest => dest.SellerName, 
                opt => opt.MapFrom(x => $"{x.Seller.FirstName} {x.Seller.LastName}"));
    }
}