using AutoMapper;

namespace CarDealer
{
    using Data;
    using DTOs.Export;
    using DTOs.Import;
    using Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //IMPORT

            //Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();

            //Part
            this.CreateMap<ImportPartDto, Part>();

            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForMember(dest => dest.PartsCars,
                    opt => opt.MapFrom(src => src
                        .Parts
                        .DistinctBy(x => x.PartId)
                        .Select(pi => new PartCar()
                        {
                            PartId = pi.PartId,
                        })));

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>();

            //Sale
            this.CreateMap<ImportSaleDto, Sale>();

            //EXPORT

            //Car
            this.CreateMap<Car, ExportCarDto>()
                .ForMember(d => d.Parts,
                    o => o.MapFrom(s => s.PartsCars.Select(pc => new ExportCarPartDto()
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price,
                    })
                        .OrderByDescending(p => p.Price)));

            this.CreateMap<Car, ExportBmwCarDto>();

            //Supplier
            this.CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(d => d.PartsCount,
                    o => o.MapFrom(s => s.Parts.Count));

            //Product
            this.CreateMap<Part, ExportCarPartDto>();

            //Customer
            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d => d.FullName,
                    o => o.MapFrom(s => s.Name))
                .ForMember(d => d.CarsBought,
                    o => o.MapFrom(s => s.Sales.Count))
                .ForMember(d => d.MoneySpent,
                    o => o.MapFrom(s => s.Sales.Select(s => s.Car)
                        .SelectMany(c => c.PartsCars).Sum(pc => pc.Part.Price)));
        }
    }
}
