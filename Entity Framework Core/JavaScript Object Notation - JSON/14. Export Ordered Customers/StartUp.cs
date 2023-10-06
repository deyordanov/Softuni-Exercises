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

            Console.WriteLine(GetOrderedCustomers(context));
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new CustomerProfile()));

            IMapper mapper = new Mapper(config);

            CustomerDto[] dtos = context.Customers
                .AsNoTracking()
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ProjectTo<CustomerDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(dtos, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
        }
    }
}