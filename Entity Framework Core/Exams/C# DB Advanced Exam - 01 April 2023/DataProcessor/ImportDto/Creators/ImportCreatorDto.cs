using Boardgames.Common;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto.Creators;

using System.Xml.Serialization;

[XmlType("Creator")]
public class ImportCreatorDto
{
    [Required]
    [XmlElement(nameof(FirstName))]
    [MinLength(ValidationConstants.CreatorFirstNameMinLength)]
    [MaxLength(ValidationConstants.CreatorFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [XmlElement(nameof(LastName))]
    [MinLength(ValidationConstants.CreatorLastNameMinLength)]
    [MaxLength(ValidationConstants.CreatorLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [XmlArray(nameof(Boardgames))]
    public ImportBoardgameDto[] Boardgames { get; set; } = null!;
}