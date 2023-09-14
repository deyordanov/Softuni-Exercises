namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlRoot("Users")]
public class ExportUsersAndProductsWrapperDto
{
    [XmlElement("count")]
    public int Count { get; set; }
    [XmlArray("users")]
    public ExportUsersAndProductsUserDto[] Users { get; set; } = null!;
}