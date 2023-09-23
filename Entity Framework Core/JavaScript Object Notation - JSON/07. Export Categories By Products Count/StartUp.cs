using ProductShop.Data;

namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Profiles;
    using DTOs.Export;
    using DTOs.Export.SoldProducts;
    using DTOs.Import;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            
            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new CategoriesByCountProfile()));

            IMapper mapper = new Mapper(config);

            CategoriesByCountDto[] dtos = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .ProjectTo<CategoriesByCountDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(dtos, Formatting.Indented);
        }
    }
}