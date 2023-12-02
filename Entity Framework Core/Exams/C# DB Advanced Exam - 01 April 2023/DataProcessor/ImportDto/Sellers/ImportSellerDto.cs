using Boardgames.Common;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto.Sellers;

using Newtonsoft.Json;

public class ImportSellerDto
{
    [Required]
    [JsonProperty(nameof(Name))]
    [MinLength(ValidationConstants.SellerNameMinLength)]
    [MaxLength(ValidationConstants.SellerNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Address))]
    [MinLength(ValidationConstants.SellerAddressMinLength)]
    [MaxLength(ValidationConstants.SellerAddressMaxLength)]
    public string Address { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Country))]
    public string Country { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Website))]
    [RegularExpression(ValidationConstants.SellerWebsiteRegEx)]
    public string Website { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Boardgames))]
    public int[] Boardgames { get; set; } = null!;
}