namespace Invoices.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enums;
using Common;

public class Invoice
{
    [Key] public int Id { get; set; }

    [Required] public int Number { get; set; }

    [Required] public DateTime IssueDate { get; set; }

    [Required] public DateTime DueDate { get; set; }

    [Required] public decimal Amount { get; set; }

    [Required]
    [MaxLength(ValidationConstants.InvoiceCurrencyTypeMaxValue)]
    public CurrencyType CurrencyType { get; set; }

    [Required]
    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }

    public Client Client { get; set; } = null!;
}