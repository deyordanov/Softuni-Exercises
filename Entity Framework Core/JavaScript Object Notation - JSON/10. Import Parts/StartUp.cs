namespace CarDealer
{
    using AutoMapper;
    using Data;
    using Data.Profiles;
    using DTOs.Import;
    using Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            string json = File.ReadAllText("../../../Datasets/parts.json");

            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(ImportParts(context, json));
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg
                .AddProfile(new PartProfile()));

            IMapper mapper = new Mapper(config);

            PartDto[]? partDtos = JsonConvert
                .DeserializeObject<PartDto[]>(inputJson);

            Part[] parts = mapper
                .Map<Part[]>(partDtos)
                .Where(p => context.Suppliers.Find(p.SupplierId) != null)
                .ToArray();

            context.Parts
                .AddRange(parts);

            context
                .SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }
    }
}