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
            
            Console.WriteLine(GetSoldProducts(context));
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new SoldProductsProfile()));

            IMapper mapper = new Mapper(config);

            var a = context.Products
                .ProjectTo<SoldProductsProductDto>(mapper.ConfigurationProvider);

            SoldProductsUserDto[] dtos = context.Users
                .Include(u => u.ProductsSold)
                .AsNoTracking()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<SoldProductsUserDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(dtos, Formatting.Indented);
        }
    }
}