namespace Invoices.DataProcessor.ImportDto.Invoices;

using System.ComponentModel.DataAnnotations;
using Data.Common;
using Newtonsoft.Json;

public class InvoiceDto
{
    [Required]
    [JsonProperty(nameof(Number))]
    [Range(ValidationConstants.InvoiceNumberMinRange, ValidationConstants.InvoiceNumberMaxRange)]
    public int Number { get; set; }

    [Required]
    [JsonProperty(nameof(IssueDate))]
    public DateTime IssueDate { get; set; }

    [Required]
    [JsonProperty(nameof(DueDate))]
    public DateTime DueDate { get; set; }

    [Required]
    [JsonProperty(nameof(Amount))]
    public decimal Amount { get; set; }

    [Required]
    [JsonProperty(nameof(CurrencyType))]
    [Range(ValidationConstants.InvoiceCurrencyTypeMinValue, ValidationConstants.InvoiceCurrencyTypeMaxValue)]
    public int CurrencyType { get; set; }

    [Required]
    [JsonProperty(nameof(ClientId))]
    public int ClientId { get; set; }
}