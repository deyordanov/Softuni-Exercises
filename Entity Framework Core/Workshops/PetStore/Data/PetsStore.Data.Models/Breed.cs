namespace PetsStore.Data.Models;

using System.ComponentModel.DataAnnotations;
using Common;
using Data.Common.Models;

public class Breed : BaseDeletableModel<int>
{
    [MaxLength(BreedValidationConstants.NameMaxLength)]
    public string Name { get; set; } = null!;
}