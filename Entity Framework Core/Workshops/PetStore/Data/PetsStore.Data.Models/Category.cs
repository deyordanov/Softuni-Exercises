namespace PetsStore.Data.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PetsStore.Data.Common.Models;
using PetsStore.Data.Models.Common;

public class Category : BaseDeletableModel<int>
{
    public Category()
    {
        this.Pets = new HashSet<Pet>();
        this.Products = new HashSet<Product>();
    }

    [MaxLength(CategoryValidationConstants.NameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Pet> Pets { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}