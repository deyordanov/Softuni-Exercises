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

            string xml = File.ReadAllText("../../../Datasets/categories-products.xml");

            Console.WriteLine(ImportCategoryProducts(context, xml));
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new ProductShopProfile()));

            IMapper mapper = new Mapper(config);

            XmlRootAttribute root = new XmlRootAttribute("CategoryProducts");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoriesAndProductsDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportCategoriesAndProductsDto[]? importedDtos =
                (ImportCategoriesAndProductsDto[]?)serializer.Deserialize(reader);

            CategoryProduct[] categoryProducts =
                mapper.Map<CategoryProduct[]>(importedDtos);

            context.CategoryProducts.AddRange(categoryProducts
                .Where(cp => context.Categories.Find(cp.CategoryId) != null &&
                             context.Products.Find(cp.ProductId) != null));

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }
    }
}