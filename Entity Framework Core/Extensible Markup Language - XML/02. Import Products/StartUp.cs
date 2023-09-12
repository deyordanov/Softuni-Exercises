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

            string xml = File.ReadAllText("../../../Datasets/products.xml");

            Console.WriteLine(ImportProducts(context, xml));
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new ProductShopProfile()));

            IMapper mapper = new Mapper(config);

            XmlRootAttribute root = new XmlRootAttribute("Products");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportProductDto[]? importedDtos =
                (ImportProductDto[]?)serializer.Deserialize(reader);

            Product[] products =
                mapper.Map<Product[]>(importedDtos);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}