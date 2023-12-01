namespace Invoices.DataProcessor.ExportDto.Clients;

using System.Xml.Serialization;

[XmlType("Client")]
public class ExportClientDto
{
    [XmlAttribute(nameof(InvoicesCount))]
    public int InvoicesCount { get; set; }

    [XmlElement(nameof(ClientName))]
    public string ClientName { get; set; } = null!;

    [XmlElement(nameof(VatNumber))]
    public string VatNumber { get; set; } = null!;

    [XmlArray(nameof(Invoices))]
    public ExportInvoiceDto[] Invoices { get; set; } = null!;
}