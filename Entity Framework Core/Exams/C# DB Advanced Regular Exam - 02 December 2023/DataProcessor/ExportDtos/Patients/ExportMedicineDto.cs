namespace Medicines.DataProcessor.ExportDtos.Patients;

using System.Xml.Serialization;

[XmlType("Medicine")]
public class ExportMedicineDto
{
    [XmlAttribute(nameof(Category))]
    public string Category { get; set; } = null!;

    [XmlElement(nameof(Name))]
    public string Name { get; set; } = null!;

    [XmlElement(nameof(Price))] 
    public string Price { get; set; } = null!;

    [XmlElement(nameof(Producer))]
    public string Producer { get; set; } = null!;

    [XmlElement("BestBefore")]
    public string ExpiryDate { get; set; } = null!;
}