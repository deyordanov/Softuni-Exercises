using CarDealer.Data;

namespace CarDealer
{
    using System.Xml.Serialization;
    using AutoMapper;
    using CarDealer.Models;
    using DTOs.Import;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            string xml = File.ReadAllText("../../../Datasets/suppliers.xml");

            Console.WriteLine(ImportSuppliers(context, xml));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(config);

            using StringReader reader = new StringReader(inputXml);

            XmlRootAttribute root = new XmlRootAttribute("Suppliers");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDto[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ImportSupplierDto[]? importedDtos = (ImportSupplierDto[]?)serializer.Deserialize(reader);

            Supplier[] suppliers =
                mapper.Map<Supplier[]>(importedDtos);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }
    }
}