namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("sale")]
public class ExportSaleDto
{
    [XmlElement("car")]
    public ExportCarDto Car { get; set; } = null!;
    [XmlElement("discount")]
    public decimal Discount { get; set; }
    [XmlElement("customer-name")]
    public string CustomerName { get; set; } = null!;
    [XmlElement("price")]
    public double Price { get; set; }
    [XmlElement("price-with-discount")]
    public double PriceWithDiscount { get; set; }
}