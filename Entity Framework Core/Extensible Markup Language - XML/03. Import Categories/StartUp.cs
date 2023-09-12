using ProductShop.Data;

namespace ProductShop
{
    using System.Xml.Serialization;
    using AutoMapper;
    using DTOs.Import;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string xml = File.ReadAllText("../../../Datasets/categories.xml");

            Console.WriteLine(ImportCategories(context, xml));
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new ProductShopProfile()));

            IMapper mapper = new Mapper(config);

            XmlRootAttribute root = new XmlRootAttribute("Categories");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportCategoryDto[]? importedDtos =
                (ImportCategoryDto[]?)serializer.Deserialize(reader);

            Category[] categories =
                mapper.Map<Category[]>(importedDtos);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
    }
}