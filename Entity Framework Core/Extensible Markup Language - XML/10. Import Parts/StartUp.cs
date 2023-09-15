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

            string xml = File.ReadAllText("../../../Datasets/parts.xml");

            Console.WriteLine(ImportParts(context, xml));
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(config);

            ImportPartDto[] importedDtos = 
                XmlHelper
                .CollectionDeserializer<ImportPartDto>(inputXml, "Parts");

            Part[] parts = 
                mapper.Map<Part[]>(importedDtos
                    .Where(p => context.Suppliers
                        .Find(p.SupplierId) != null));

            context.Parts
                .AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }
    }
}