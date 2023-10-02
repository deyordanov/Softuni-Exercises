namespace PetsStore.Data.Models;

using System.ComponentModel.DataAnnotations;
using Common;
using Data.Common.Models;

public class DeliveryType : BaseDeletableModel<int>
{
    [MaxLength(DeliveryTypeValidationConstants.NameMaxLength)]
    public string Name { get; set; } = null!;
}