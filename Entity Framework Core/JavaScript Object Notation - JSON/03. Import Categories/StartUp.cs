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

            string json = File.ReadAllText("../../../Datasets/categories.json");
            
            Console.WriteLine(ImportCategories(context, json));
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new CategoryProfile()));

            IMapper mapper = new Mapper(config);

            CategoryDto[]? categoryDtos =
                JsonConvert.DeserializeObject<CategoryDto[]>(inputJson);

            Category[]? categories =
                mapper.Map<Category[]>(categoryDtos
                    .Where(dto => dto.Name != null));

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
    }
}