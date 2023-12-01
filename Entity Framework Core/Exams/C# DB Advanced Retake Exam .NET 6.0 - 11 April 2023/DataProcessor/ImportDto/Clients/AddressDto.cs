namespace Invoices.DataProcessor.ImportDto.Clients;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Data.Common;

[XmlType("Address")]
public class AddressDto
{
    [Required]
    [XmlElement("StreetName")]
    [MaxLength(ValidationConstants.AddressStreetNameMaxLength)]
    [MinLength(ValidationConstants.AddressStreetNameMinLength)]
    public string StreetName { get; set; } = null!;

    [Required]
    [XmlElement("StreetNumber")]
    public int StreetNumber { get; set; }

    [Required]
    [XmlElement("PostCode")]
    public string PostCode { get; set; } = null!;

    [Required]
    [XmlElement("City")]
    [MaxLength(ValidationConstants.AddressCityMaxLength)]
    [MinLength(ValidationConstants.AddressCityMinLength)]
    public string City { get; set; } = null!;

    [Required]
    [XmlElement("Country")]
    [MaxLength(ValidationConstants.AddressCountryMaxLength)]
    [MinLength(ValidationConstants.AddressCountryMinLength)]
    public string Country { get; set; } = null!;
}