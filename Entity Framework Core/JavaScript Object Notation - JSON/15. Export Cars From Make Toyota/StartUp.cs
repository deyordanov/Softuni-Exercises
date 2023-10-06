namespace CarDealer
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.ExportProfiles;
    using DTOs.Export;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(GetCarsFromMakeToyota(context));
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new CarProfile()));

            IMapper mapper = new Mapper(config);

            List<CarDto> dtos = context.Cars
                .AsNoTracking()
                .Where(c => c.Make == "Toyota")
                .ProjectTo<CarDto>(mapper.ConfigurationProvider)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToList();

            return JsonConvert.SerializeObject(dtos, Formatting.Indented);
        }
    }
}