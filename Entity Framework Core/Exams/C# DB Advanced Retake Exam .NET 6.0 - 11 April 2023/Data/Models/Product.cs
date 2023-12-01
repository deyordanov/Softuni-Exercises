namespace Invoices.Data.Models;

using System.ComponentModel.DataAnnotations;
using Common;
using Enums;

public class Product
{
    public Product()
    {
        this.ProductsClients = new HashSet<ProductClient>();
    }

    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ProductNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required] public decimal Price { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ProductCategoryTypeMaxRange)]
    public CategoryType CategoryType { get; set; }

    public ICollection<ProductClient> ProductsClients { get; set; }
}