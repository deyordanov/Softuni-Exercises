using ProductShop.Data;

namespace ProductShop
{
    using AutoMapper;
    using Data.Profiles;
    using DTOs.Import;
    using Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string json = File.ReadAllText("../../../Datasets/products.json");
            
            Console.WriteLine(ImportProducts(context, json));
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new ProductProfile()));

            IMapper mapper = new Mapper(config);

            ProductDto[]? productDtos =
                JsonConvert.DeserializeObject<ProductDto[]>(inputJson);

            Product[] products =
                mapper.Map<Product[]>(productDtos);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}