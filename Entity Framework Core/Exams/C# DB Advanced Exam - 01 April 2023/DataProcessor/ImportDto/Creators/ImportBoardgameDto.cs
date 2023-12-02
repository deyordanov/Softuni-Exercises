using Boardgames.Common;
using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto.Creators;

using System.Xml.Serialization;

[XmlType("Boardgame")]
public class ImportBoardgameDto
{
    [Required]
    [XmlElement(nameof(Name))]
    [MinLength(ValidationConstants.BoardgameNameMinLength)]
    [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement(nameof(Rating))]
    [Range(ValidationConstants.BoardgameRatingMinRange, ValidationConstants.BoardgameRatingMaxRange)]
    public double Rating { get; set; }

    [Required]
    [XmlElement(nameof(YearPublished))]
    [Range(ValidationConstants.BoardgameYearPublishedMinRange, ValidationConstants.BoardgameYearPublishedMaxRange)]
    public int YearPublished { get; set; }

    [Required]
    [XmlElement(nameof(CategoryType))]
    [Range(ValidationConstants.BoardgameCategoryTypeMinRange, ValidationConstants.BoardgameCategoryTypeMaxRange)]
    public int CategoryType { get; set; }

    [Required]
    [XmlElement(nameof(Mechanics))]
    public string Mechanics { get; set; } = null!;
}