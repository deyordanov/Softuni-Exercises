namespace ProductShop.Data.Profiles;

using AutoMapper;
using DTOs.Export.UsersAndProducts;
using Models;

public class UsersAndProductsProfile : Profile
{
    public UsersAndProductsProfile()
    {
        CreateMap<User, UserDestination>()
            .ForMember(dest => dest.SoldProducts, opt => opt.MapFrom(src => new SoldProductsResult
            {
                Count = src.ProductsSold
                    .Count(p => p.Buyer != null),
                Products = src.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(p =>
                    new ProductDestination
                    {
                        Price = p.Price,
                        Name = p.Name,
                    }).ToList()
            }));

        CreateMap<Product, ProductDestination>();
    }
}