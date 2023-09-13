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

            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new ProductShopProfile()));

            IMapper mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();

            ExportCategoryProductCountDto[] dtos = context.Categories
                .ProjectTo<ExportCategoryProductCountDto>(mapper.ConfigurationProvider)
                .ToArray();

            XmlRootAttribute root = new XmlRootAttribute("Categories");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCategoryProductCountDto[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            dtos = dtos
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            serializer.Serialize(writer, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}