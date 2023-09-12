namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("Category")]
public class ExportCategoryProductCountDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;
    [XmlElement("count")]
    public int Count { get; set; }
    [XmlElement("averagePrice")]
    public decimal AveragePrice { get; set; }
    [XmlElement("totalRevenue")]
    public decimal TotalRevenue { get; set; }
}