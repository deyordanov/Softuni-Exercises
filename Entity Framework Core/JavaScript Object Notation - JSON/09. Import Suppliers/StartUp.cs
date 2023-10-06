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
            string json = File.ReadAllText("../../../Datasets/suppliers.json");

            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(ImportSuppliers(context, json));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new SupplierProfile()));

            IMapper mapper = new Mapper(config);

            SupplierDto[]? supplierDtos = JsonConvert.DeserializeObject<SupplierDto[]>(inputJson);

            Supplier[]? suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }
    }
}