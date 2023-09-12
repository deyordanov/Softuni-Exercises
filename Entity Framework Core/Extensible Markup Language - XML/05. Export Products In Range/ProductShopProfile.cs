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
        }
    }
}
