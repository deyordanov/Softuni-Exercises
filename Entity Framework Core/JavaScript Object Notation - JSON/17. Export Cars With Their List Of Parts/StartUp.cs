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

            Console.WriteLine(GetCarsWithTheirListOfParts(context));
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var config = new MapperConfiguration(src => src.AddProfile(new PartsProfile()));

            IMapper mapper = new Mapper(config);

            PartsWrapperDto[] dtos = context.Cars
                .ProjectTo<PartsWrapperDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(dtos, Formatting.Indented);
        }
    }
}