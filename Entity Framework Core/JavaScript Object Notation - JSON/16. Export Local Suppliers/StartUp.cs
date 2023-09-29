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

            Console.WriteLine(GetLocalSuppliers(context));
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new SupplierProfile()));

            IMapper mapper = new Mapper(config);

            SupplierDto[] dtos = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<SupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(dtos, Formatting.Indented);
        }
    }
}