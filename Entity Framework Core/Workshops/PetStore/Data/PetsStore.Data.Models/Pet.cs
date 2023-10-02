namespace PetsStore.Data.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetsStore.Data.Common.Models;
using PetsStore.Data.Models.Common;

public class Pet : BaseDeletableModel<string>
{
    public Pet()
    {
        this.Id = Guid.NewGuid().ToString();
    }

    [MaxLength(PetValidationConstants.NameMaxLength)]
    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public decimal Price { get; set; }

    public string ImageURL { get; set; } = null!;

    [ForeignKey(nameof(Breed))]
    public int BreedId { get; set; }

    public virtual Breed Breed { get; set; } = null!;

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }

    [ForeignKey(nameof(Owner))]
    public string ClientId { get; set; }

    public virtual Client Owner { get; set; }

    [ForeignKey(nameof(Store))]
    public string StoreId { get; set; }

    public virtual Store Store { get; set; }

}