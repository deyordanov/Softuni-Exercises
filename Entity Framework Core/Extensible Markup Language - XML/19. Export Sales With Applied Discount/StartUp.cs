using CarDealer.Data;

namespace CarDealer
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using DTOs.Export;
    using Models;
    using DTOs.Import;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("sales");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSaleDto[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            ExportSaleDto[] dtos = context.Sales
                .ProjectTo<ExportSaleDto>(mapper.ConfigurationProvider)
                .ToArray();

            serializer.Serialize(writer, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}