namespace RealEstates.Services.Models;

using System.Xml.Serialization;

[XmlType("Tag")]
public class TagDataDto
{
    [XmlElement("TagName")]
    public string Name { get; set; } = null!;
}