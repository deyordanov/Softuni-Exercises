namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("customer")]
public class ExportCustomerDto
{
    [XmlAttribute("full-name")]
    public string FullName { get; set; } = null!;
    [XmlAttribute("bought-cars")]
    public int CarsBought { get; set; }

    [XmlAttribute("spent-money")]
    public decimal MoneySpent { get; set; }
}