namespace ProductShop.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Product")]
public class ImportProductDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;
    [XmlElement("price")]
    public decimal Price { get; set; }
    [XmlElement("sellerId")]
    public int SellerId { get; set; }
    [XmlElement("buyerId")]
    public int? BuyerId { get; set; }
}