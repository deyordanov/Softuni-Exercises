namespace CarDealer
{
    using AutoMapper;
    using Castle.Core.Resource;
    using Data;
    using Data.Profiles;
    using DTOs.Import;
    using Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            string json = File.ReadAllText("../../../Datasets/sales.json");

            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(ImportSales(context, json));
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new SaleProfile()));

            IMapper mapper = new Mapper(config);

            SaleDto[]? saleDtos = JsonConvert.DeserializeObject<SaleDto[]>(inputJson);

            Sale[] sales = mapper.Map<Sale[]>(saleDtos);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }
    }
}