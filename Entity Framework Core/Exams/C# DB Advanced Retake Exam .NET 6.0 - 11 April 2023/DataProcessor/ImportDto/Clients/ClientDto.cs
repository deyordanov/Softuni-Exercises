namespace Invoices.DataProcessor.ImportDto.Clients;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Data.Common;

[XmlType("Client")]
public class ClientDto
{
    [Required]
    [XmlElement("Name")]
    [MaxLength(ValidationConstants.ClientNameMaxLength)]
    [MinLength(ValidationConstants.ClientNameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("NumberVat")]
    [MaxLength(ValidationConstants.ClientVatNumberMaxLength)]
    [MinLength(ValidationConstants.ClientVatNumberMinLength)]
    public string NumberVat { get; set; } = null!;

    [XmlArray("Addresses")]
    public AddressDto[] Addresses { get; set; } = null!;
}