namespace CarDealer.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Customer")]
public class ImportCustomerDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;
    [XmlElement("birthDate")]
    public DateTime BirthDate { get; set; }
    [XmlElement("isYoungDriver")]
    public bool IsYoungDriver { get; set; }
}