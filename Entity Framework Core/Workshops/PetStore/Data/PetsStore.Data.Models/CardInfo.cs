namespace PetsStore.Data.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetsStore.Data.Common.Models;
using PetsStore.Data.Models.Common;

public class CardInfo : BaseDeletableModel<string>
{
    public CardInfo()
    {
        this.Id = Guid.NewGuid().ToString();
    }

    [MaxLength(CardInfoValidationConstants.CardNumberMaxLength)]
    public string CardNumber { get; set; } = null!;

    [MaxLength(CardInfoValidationConstants.ExpirationDateMaxLength)]
    public string ExpirationDate { get; set; } = null!;

    [MaxLength(CardInfoValidationConstants.CardHolderMaxLength)]
    public string CardHolder { get; set; } = null!;

    // ReSharper disable once InconsistentNaming
    [MaxLength(CardInfoValidationConstants.CvcMaxLength)]
    public string CVC { get; set; } = null!;

    [ForeignKey(nameof(Client))]
    public string ClientId { get; set; }

    public virtual Client Client { get; set; }
}