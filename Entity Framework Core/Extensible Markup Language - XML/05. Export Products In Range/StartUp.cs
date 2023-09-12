using ProductShop.Data;

namespace ProductShop
{
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using DTOs.Export;
    using DTOs.Import;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string xml = File.ReadAllText("../../../Datasets/categories-products.xml");

            Console.WriteLine(GetProductsInRange(context));
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new ProductShopProfile()));

            IMapper mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();

            ExportProductsInRangeDto[] dtos = context.Products
                .Include(p => p.Buyer)
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductsInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            XmlRootAttribute root = new XmlRootAttribute("Products");

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProductsInRangeDto[]), root);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}