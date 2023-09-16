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

            string xml = File.ReadAllText("../../../Datasets/customers.xml");

            Console.WriteLine(ImportCustomers(context, xml));
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(config);

            XmlRootAttribute root = new XmlRootAttribute("Cars");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportCarDto[]? importedDtos =
                (ImportCarDto[]?)serializer.Deserialize(reader);

            Car[] cars =
                mapper.Map<Car[]>(importedDtos);

            context.Cars
                .AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Length}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(config);

            XmlRootAttribute root = new XmlRootAttribute("Customers");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportCustomerDto[]? importedDtos =
                (ImportCustomerDto[]?)serializer.Deserialize(reader);

            Customer[] customers =
                mapper.Map<Customer[]>(importedDtos);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }
    }
}