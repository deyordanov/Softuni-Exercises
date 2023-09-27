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
            string json = File.ReadAllText("../../../Datasets/customers.json");

            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(ImportCustomers(context, json));
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new CustomerProfile()));

            IMapper mapper = new Mapper(config);

            CustomerDto[]? customerDtos = JsonConvert.DeserializeObject<CustomerDto[]>(inputJson);

            Customer[] customers = mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }
    }
}