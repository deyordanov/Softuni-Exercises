using AutoMapper;

namespace Invoices
{
    using Data.Models;
    using DataProcessor.ImportDto.Clients;
    using DataProcessor.ImportDto.Invoices;
    using DataProcessor.ImportDto.Products;

    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            CreateMap<InvoiceDto, Invoice>();

            CreateMap<ProductDto, Product>();
        }
    }


}