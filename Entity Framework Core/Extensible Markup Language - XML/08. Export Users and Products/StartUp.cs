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

            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new ProductShopProfile()));

            IMapper mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();

            ExportUsersAndProductsUserDto[] dtos = context.Users
                .AsNoTracking()
                .Where(u => u.ProductsSold.Count >= 1)
                .ProjectTo<ExportUsersAndProductsUserDto>(mapper.ConfigurationProvider)
                .OrderByDescending(d => d.SoldProducts.Count)
                .Take(10)
                .ToArray();

            ExportUsersAndProductsWrapperDto wrapper = new ExportUsersAndProductsWrapperDto()
            {
                Count = context.Users
                    .Count(u => u.ProductsSold.Count >= 1),
                Users = dtos
            };

            XmlRootAttribute root = new XmlRootAttribute("Users");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUsersAndProductsWrapperDto), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, wrapper, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}