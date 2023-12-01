namespace Invoices.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductClient
{
    [ForeignKey(nameof(Product))] public int ProductId { get; set; }

    public Product Product { get; set; } = null!;

    [ForeignKey(nameof(Client))] public int ClientId { get; set; }

    public Client Client { get; set; } = null!;
}