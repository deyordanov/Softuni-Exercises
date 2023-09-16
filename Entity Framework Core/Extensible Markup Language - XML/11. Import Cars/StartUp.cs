using CarDealer.Data;

namespace CarDealer
{
    using System.IO;
    using System.Xml.Serialization;
    using AutoMapper;
    using CarDealer.Models;
    using DTOs.Import;
    using Microsoft.EntityFrameworkCore;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            string xml = File.ReadAllText("../../../Datasets/cars.xml");

            Console.WriteLine(ImportCars(context, xml));
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
    }
}