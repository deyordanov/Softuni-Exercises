namespace Invoices.DataProcessor
{
    using ExportDto.Clients;
    using Invoices.Data;
    using Invoices.DataProcessor.ImportDto.Clients;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Utilities;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportClientDto[]), new XmlRootAttribute("Clients"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            ExportClientDto[] clients = context
                .Clients
                .ToArray()
                .Where(c => c.Invoices.Count >= 1 && c.Invoices.Any(i => i.IssueDate >= date))
                .Select(c => new ExportClientDto()
                {
                    InvoicesCount = c.Invoices.Count,
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportInvoiceDto()
                        {
                            InvoiceNumber = i.Number,
                            InvoiceAmount = i.Amount,
                            DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            Currency = i.CurrencyType.ToString(),
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.InvoicesCount)
            .ThenBy(c => c.ClientName)
                .ToArray();

            xmlSerializer.Serialize(sw, clients, namespaces);
            return sb.ToString().TrimEnd();
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var products = context
                .Products
                .AsNoTracking()
                .Where(p => p.ProductsClients.Count >= 1 && p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(pc => new
                        {
                            Name = pc.Client.Name,
                            NumberVat = pc.Client.NumberVat,
                        })
                        .OrderBy(c => c.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}