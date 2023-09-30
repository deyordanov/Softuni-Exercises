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

            Console.WriteLine(GetTotalSalesByCustomer(context));
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new SalesCustomerProfile()));

            IMapper mapper = new Mapper(config);

            SalesCustomerDto[] dtos = context.Customers
                .AsNoTracking()
                .Where(c => c.Sales.Count >= 1)
                .ProjectTo<SalesCustomerDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(dtos
                .OrderByDescending(c => c.MoneySpent)
                .ThenByDescending(c => c.CarsBought), Formatting.Indented);
        }
    }
}