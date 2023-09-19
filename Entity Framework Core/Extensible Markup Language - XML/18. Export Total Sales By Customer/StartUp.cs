using CarDealer.Data;

namespace CarDealer
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using DTOs.Export;
    using Models;
    using DTOs.Import;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(GetTotalSalesByCustomer(context));
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            IMapper mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("customers");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCustomerDto[]), root);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            ExportCustomerDto[] dtos = context.Sales
                .Where(s => context.Sales
                    .Count(x => s.CustomerId == x.CustomerId) >= 1)
                .Select(s => new ExportCustomerDto()
                {
                    FullName = s.Customer.Name,
                    CarsBought = context.Sales
                        .Count(x => s.CustomerId == x.CustomerId),
                    MoneySpent = s.Customer.IsYoungDriver == false ?
                        context.Sales
                            .Where(x => s.CustomerId == x.CustomerId)
                            .Select(c => c.Car)
                            .SelectMany(x => x.PartsCars)
                            .Sum(pc => pc.Part.Price) :
                        context.Sales
                            .Where(x => s.CustomerId == x.CustomerId)
                            .Select(c => c.Car)
                            .SelectMany(x => x.PartsCars)
                            .Sum(pc => pc.Part.Price) -
                        (context.Sales
                            .Where(x => s.CustomerId == x.CustomerId)
                            .Select(c => c.Car)
                            .SelectMany(x => x.PartsCars)
                            .Sum(pc => (context.Sales
                                .Where(x => x.CustomerId == s.CustomerId && x.CarId == s.CarId).First().Discount / 100M) * pc.Part.Price))
                })
                .OrderByDescending(c => c.MoneySpent)
                .ToArray();

            serializer.Serialize(writer, dtos, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}