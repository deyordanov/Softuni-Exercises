namespace ProductShop.Data.Profiles;

using AutoMapper;
using DTOs.Export.SoldProducts;
using Models;

public class SoldProductsProfile : Profile
{
    public SoldProductsProfile()
    {
        //Applying filter through the AutoMapper
        CreateMap<User, SoldProductsUserDto>()
            .ForMember(dest => dest.ProductsSold, 
                opt => opt.MapFrom(x => x.ProductsSold.Where(p => p.Buyer != null)));

        CreateMap<Product, SoldProductsProductDto>();

        // IMapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Product, SoldProductsProductDto>()
        //     .ForMember(dest => dest.BuyerFirstName, 
        //         opt => opt.MapFrom(x => x.Seller.FirstName))
        //     .ForMember(dest => dest.BuyerLastName,
        //         opt => opt.MapFrom(x => x.Seller.LastName))));

        // CreateMap<User, SoldProductsUserDto>()
        //     .ForMember(dest => dest.SoldProducts,
        //         opt => opt.MapFrom(x => x.ProductsBought.Select(p => mapper.Map<SoldProductsProductDto>(p))));
    }
}