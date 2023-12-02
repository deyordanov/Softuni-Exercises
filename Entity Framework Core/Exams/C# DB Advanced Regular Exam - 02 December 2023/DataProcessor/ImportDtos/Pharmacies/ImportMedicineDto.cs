using Medicines.Common;
using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos.Pharmacies;

using Medicines.Data.Models.Enums;
using System.Xml.Serialization;

[XmlType("Medicine")]
public class ImportMedicineDto
{
    [Required]
    [XmlElement(nameof(Name))]
    [MinLength(ValidationConstants.MedicineNameMinLength)]
    [MaxLength(ValidationConstants.MedicineNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement(nameof(Price))]
    [Range((double)ValidationConstants.MedicinePriceMinRange, (double)ValidationConstants.MedicinePriceMaxRange)]
    public decimal Price { get; set; }

    [Required]
    [XmlAttribute("category")]
    [Range(ValidationConstants.MedicineCategoryMinRange, ValidationConstants.MedicineCategoryMaxRange)]
    public int Category { get; set; }

    [Required]
    [XmlElement(nameof(ProductionDate))]
    public string ProductionDate { get; set; } = null!;

    [Required]
    [XmlElement(nameof(ExpiryDate))]
    public string ExpiryDate { get; set; } = null!;

    [Required]
    [XmlElement(nameof(Producer))]
    [MinLength(ValidationConstants.MedicineProducerMinLength)]
    [MaxLength(ValidationConstants.MedicineProducerMaxLength)]
    public string Producer { get; set; } = null!;
}