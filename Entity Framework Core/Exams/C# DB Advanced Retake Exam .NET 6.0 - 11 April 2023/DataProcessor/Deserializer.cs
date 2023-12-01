namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.Metrics;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto.Clients;
    using ImportDto.Invoices;
    using ImportDto.Products;
    using Invoices.Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            
            XmlSerializer serializer = new XmlSerializer(typeof(ClientDto[]), new XmlRootAttribute("Clients"));

            using StringReader reader = new StringReader(xmlString);

            ClientDto[] clientsDto = (ClientDto[])serializer.Deserialize(reader)!;

            List<Client> clients = new List<Client>();

            foreach (ClientDto clientDto in clientsDto)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat
                };

                foreach (AddressDto addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Address address = new Address()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country
                    };

                    client.Addresses.Add(address);
                }
                clients.Add(client);
                sb.AppendLine(String.Format(SuccessfullyImportedClients, client.Name));
            }

            context.Clients.AddRange(clients);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(InvoicesProfile));
            });

            IMapper mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();

            InvoiceDto[] importedInvoices = JsonConvert.DeserializeObject<InvoiceDto[]>(jsonString)!;

            ICollection<Invoice> validInvoices = new HashSet<Invoice>();

            foreach (InvoiceDto invoiceDto in importedInvoices)
            {
                if (!IsValid(invoiceDto))
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }

                if (invoiceDto.DueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture) || invoiceDto.IssueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice invoice = mapper.Map<Invoice>(invoiceDto);

                if (invoice.IssueDate > invoice.DueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));

                validInvoices.Add(invoice);
            }

            context.Invoices.AddRange(validInvoices);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(InvoicesProfile));
            });

            IMapper mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();

            ProductDto[] importedProducts = JsonConvert.DeserializeObject<ProductDto[]>(jsonString)!;

            ICollection<Product> validProducts = new HashSet<Product>();

            int[] clientIds = context.Clients.AsNoTracking().Select(c => c.Id).ToArray();

            foreach (ProductDto productDto in importedProducts)
            {
                if (!IsValid(productDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Product product = mapper.Map<Product>(productDto);

                foreach (int clientId in productDto.Clients.Distinct())
                {
                    if (!clientIds.Contains(clientId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Client client = context.Clients.Find(clientId)!;

                    product.ProductsClients.Add(new ProductClient()
                    {
                        Client = client
                    });
                }

                validProducts.Add(product);
                sb.AppendLine(String.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}