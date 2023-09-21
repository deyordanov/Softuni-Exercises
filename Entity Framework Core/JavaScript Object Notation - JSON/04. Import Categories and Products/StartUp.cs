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

            string json = File.ReadAllText("../../../Datasets/categories-products.json");
            
            Console.WriteLine(ImportCategoryProducts(context, json));
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new CategoryProductProfile()));

            IMapper mapper = new Mapper(config);

            CategoryProductDto[]? categoryProductDtos
                = JsonConvert.DeserializeObject<CategoryProductDto[]>(inputJson);

            CategoryProduct[]? categoryProducts =
                mapper.Map<CategoryProduct[]>(categoryProductDtos);

            // context.CategoriesProducts.AddRange(categoryProducts
            //     .Where(c => context.Products.Find(c.ProductId) != null &&
            //                 context.Categories.Find(c.CategoryId) != null));

            context.CategoriesProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }
    }
}