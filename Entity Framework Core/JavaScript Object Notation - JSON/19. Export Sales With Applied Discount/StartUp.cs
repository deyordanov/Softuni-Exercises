namespace CarDealer
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.ExportProfiles;
    using DTOs.Export;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var result = context.Sales
                .AsNoTracking()
                .Include(s => s.Car)
                .Include(s => s.Customer)
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("F2"),
                    price = s.Car.PartsCars.Sum(p => p.Part.Price).ToString("F2"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(p => p.Part.Price) -
                                         (s.Car.PartsCars.Sum(p => p.Part.Price) * (s.Discount / 100M))).ToString("F2")
                }).ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
    }
}