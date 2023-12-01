namespace Invoices.DataProcessor.ExportDto.Clients;

using System.Xml.Serialization;

[XmlType("Invoice")]
public class ExportInvoiceDto
{
    [XmlElement(nameof(InvoiceNumber))]
    public int InvoiceNumber { get; set; }

    [XmlElement(nameof(InvoiceAmount))]
    public decimal InvoiceAmount { get; set; }

    [XmlElement(nameof(DueDate))]
    public string DueDate { get; set; } = null!;

    [XmlElement(nameof(Currency))]
    public string Currency { get; set; } = null!;
}