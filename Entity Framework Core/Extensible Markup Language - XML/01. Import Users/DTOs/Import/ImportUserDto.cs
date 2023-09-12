namespace ProductShop.DTOs.Import;

using System.Xml.Serialization;

[XmlType("User")]
public class ImportUserDto
{
    [XmlElement("firstName")]
    public string FirstName { get; set; } = null!;
    [XmlElement("lastName")]
    public string LastName { get; set; } = null!;
    [XmlElement("age")]
    public int? Age { get; set; }
}