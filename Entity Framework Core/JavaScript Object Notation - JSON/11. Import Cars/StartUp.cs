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
            string json = File.ReadAllText("../../../Datasets/cars.json");

            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(ImportCars(context, json));
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new CarProfile()));

            IMapper mapper = new Mapper(config);

            CarDto[]? carDtos = JsonConvert.DeserializeObject<CarDto[]>(inputJson);

            Car[]? cars = mapper.Map<Car[]>(carDtos);

            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }
    }
}