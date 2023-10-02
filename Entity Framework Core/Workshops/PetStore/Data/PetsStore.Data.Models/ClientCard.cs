namespace PetsStore.Data.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetsStore.Data.Common.Models;
using Common;

public class ClientCard : BaseDeletableModel<string>
{
    public ClientCard()
    {
        this.Id = Guid.NewGuid().ToString();
    }

    [MaxLength(ClientCardValidationConstants.CardNumberMaxLength)]
    public string CardNumber { get; set; } = null!;

    public DateTime ExpirationDate { get; set; }

    public int Discount { get; set; }

    [ForeignKey(nameof(Client))]
    public string ClientId { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;
}