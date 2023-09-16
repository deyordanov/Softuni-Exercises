using CarDealer.Data;

namespace CarDealer
{
    using System.IO;
    using System.Xml.Serialization;
    using AutoMapper;
    using Models;
    using DTOs.Import;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            string xml = File.ReadAllText("../../../Datasets/sales.xml");

            Console.WriteLine(ImportSales(context, xml));
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(config);

            XmlRootAttribute root = new XmlRootAttribute("Sales");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportSaleDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportSaleDto[]? importedDtos =
                (ImportSaleDto[]?)serializer.Deserialize(reader);

            Sale[] sales =
                mapper.Map<Sale[]>(importedDtos
                    .Where(s => context.Cars
                        .Find(s.CarId) != null));

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }
    }
}