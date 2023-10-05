namespace RealEstates.Services.Models;

using System.Xml.Serialization;
[XmlType("Property")]
public class PropertyFullDataDto
{
    [XmlAttribute("Id")]
    public int Id { get; set; }
    [XmlElement("DistrictName")]
    public string DistrictName { get; set; } = null!;
    [XmlElement("Size")]
    public int Size { get; set; }
    [XmlElement("Price")]
    public int Price { get; set; }
    [XmlAttribute("BuildingType")]
    public string BuildingType { get; set; } = null!;
    [XmlAttribute("PropertyType")]
    public string PropertyType { get; set; } = null!;
    [XmlArray("Tags")]
    public TagDataDto[] Tags { get; set; } = null!;
}