using Medicines.Common;
using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos.Pharmacies;

using System.Xml.Serialization;

[XmlType("Pharmacy")]
public class ImportPharmacyDto
{
    [Required]
    [XmlAttribute("non-stop")]
    public string IsNonStop { get; set; } = null!;

    [Required]
    [XmlElement(nameof(Name))]
    [MinLength(ValidationConstants.PharmacyNameMinLength)]
    [MaxLength(ValidationConstants.PharmacyNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement(nameof(PhoneNumber))]
    [RegularExpression(ValidationConstants.PharmacyPhoneNumberRegEx)]
    [MaxLength(ValidationConstants.PharmacyPhoneNumberMaxLength)]
    public string PhoneNumber { get; set; } = null!;

    [XmlArray(nameof(Medicines))]
    public ImportMedicineDto[] Medicines { get; set; } = null!;
}