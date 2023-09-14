namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("SoldProducts")]
public class ExportUsersAndProductsSoldProductsDto
{
    [XmlElement("count")]
    public int Count { get; set; }
    [XmlArray("products")]
    public HashSet<ExportUsersAndProductsProductDto> Products { get; set; }
}