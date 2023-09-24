using ProductShop.Data;

namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Profiles;
    using DTOs.Export.UsersAndProducts;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new UsersAndProductsProfile()));

            IMapper mapper = new Mapper(config);

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .ProjectTo<UserDestination>(mapper.ConfigurationProvider)
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToList();

            UsersResults result = new UsersResults()
            {
                UsersCount = users.Count,
                Users = users
            };

            return JsonConvert.SerializeObject(result, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            });
        }
    }
}