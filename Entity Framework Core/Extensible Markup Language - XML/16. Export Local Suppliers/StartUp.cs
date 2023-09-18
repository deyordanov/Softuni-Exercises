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

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(GetLocalSuppliers(context));
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("suppliers");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSupplierDto[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            ExportSupplierDto[] dtos = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportSupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            serializer.Serialize(writer, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}