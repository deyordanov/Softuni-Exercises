namespace Invoices.DataProcessor.ImportDto.Products;

using System.ComponentModel.DataAnnotations;
using Data.Common;
using Data.Models;
using Newtonsoft.Json;

public class ProductDto
{

    [Required]
    [JsonProperty(nameof(Name))]
    [MinLength(ValidationConstants.ProductNameMinLength)]
    [MaxLength(ValidationConstants.ProductNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Price))]
    [Range((double)ValidationConstants.ProductPriceMinRange, (double)ValidationConstants.ProductPriceMaxRange)]
    public decimal Price { get; set; }

    [Required]
    [JsonProperty(nameof(CategoryType))]
    [Range(ValidationConstants.ProductCategoryTypeMinRange, ValidationConstants.ProductCategoryTypeMaxRange)]
    public int CategoryType { get; set; }

    [Required]
    [JsonProperty(nameof(Clients))]
    public int[] Clients { get; set; } = null!;

}