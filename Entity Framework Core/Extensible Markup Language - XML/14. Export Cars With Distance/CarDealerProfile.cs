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
            this.CreateMap<Car, ExportCarDto>();
        }
    }
}
