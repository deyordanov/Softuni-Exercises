namespace PetsStore.Web.ViewModels.Products;

using Data.Models;
using PetsStore.Data.Models.Common;
using Services.Mapping;
using System.ComponentModel.DataAnnotations;

public class CreateProductInputModel : IMapTo<Product>
{
    [Required(ErrorMessage = ProductValidationConstants.NameIsRequired)]
    [MaxLength(ProductValidationConstants.NameMaxLength, ErrorMessage = ProductValidationConstants.NameMaxLengthMessage)]
    [MinLength(ProductValidationConstants.NameMinLength, ErrorMessage = ProductValidationConstants.NameMinLengthMessage)]
    public string Name { get; set; }

    [Required]
    [Range(typeof(decimal), ProductValidationConstants.PriceMinValue, ProductValidationConstants.PriceMaxValue, ErrorMessage = ProductValidationConstants.PriceRangeMessage)]
    public decimal Price { get; set; }

    [Required]
    public string ImageURL { get; set; }

    public int CategoryId { get; set; }
}