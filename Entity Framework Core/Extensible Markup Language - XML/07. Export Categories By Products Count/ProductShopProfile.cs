using AutoMapper;

namespace ProductShop
{
    using DTOs.Export;
    using DTOs.Import;
    using Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //IMPORT

            //User
            this.CreateMap<ImportUserDto, User>();

            //Product
            this.CreateMap<ImportProductDto, Product>();

            //Category
            this.CreateMap<ImportCategoryDto, Category>();

            //CategoryProduct
            this.CreateMap<ImportCategoriesAndProductsDto, CategoryProduct>();

            //EXPORT

            //Product
            this.CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(dest => dest.BuyerName,
                    opt => opt.MapFrom(src => $"{src.Buyer.FirstName} {src.Buyer.LastName}"));

            //User
            this.CreateMap<User, ExportUserOneProductDto>()
                .ForMember(dest => dest.SoldProducts,
                    opt => opt.MapFrom(src => src.ProductsSold
                        .Select(p => new ExportProductOneProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price,
                        })));

            //Category
            this.CreateMap<Category, ExportCategoryProductCountDto>()
                .ForMember(dest => dest.Count,
                    opt => opt.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(dest => dest.AveragePrice,
                    opt => opt.MapFrom(src => src.CategoryProducts.Sum(cp => cp.Product.Price) / (decimal)src.CategoryProducts.Count))
                .ForMember(dest => dest.TotalRevenue,
                    opt => opt.MapFrom(src => src.CategoryProducts.Sum(cp => cp.Product
                        .Price)));
        }
    }
}
