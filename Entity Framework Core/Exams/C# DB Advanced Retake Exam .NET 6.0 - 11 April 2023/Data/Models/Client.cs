namespace Invoices.Data.Models;

using System.ComponentModel.DataAnnotations;
using Common;

public class Client
{
    public Client()
    {
        this.Invoices = new HashSet<Invoice>();
        this.Addresses = new HashSet<Address>();
        this.ProductsClients = new HashSet<ProductClient>();
    }

    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.ClientVatNumberMaxLength)]
    public string NumberVat { get; set; } = null!;

    public ICollection<Invoice> Invoices { get; set; }

    public ICollection<Address> Addresses { get; set; }

    public ICollection<ProductClient> ProductsClients { get; set; }
}