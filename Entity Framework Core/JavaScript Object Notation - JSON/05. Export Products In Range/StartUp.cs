using ProductShop.Data;

namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Profiles;
    using DTOs.Export;
    using DTOs.Import;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            
            Console.WriteLine(GetProductsInRange(context));
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new ProductInRangeProfile()));

            IMapper mapper = new Mapper(config);

            ProductsInRangeDto[] dtos = context.Products
                .AsNoTracking()
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(x => x.Price)
                .ProjectTo<ProductsInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(dtos, Formatting.Indented);
        }
    }
}