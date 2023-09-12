namespace ProductShop.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Category")]
public class ImportCategoryDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;
}