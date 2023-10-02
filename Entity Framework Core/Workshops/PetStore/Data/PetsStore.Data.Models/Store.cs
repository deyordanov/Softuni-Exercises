namespace PetsStore.Data.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetsStore.Data.Common.Models;
using PetsStore.Data.Models.Common;

public class Store : BaseDeletableModel<string>
{
    public Store()
    {
        this.Id = Guid.NewGuid().ToString();

        this.Products = new HashSet<Product>();
        this.Pets = new HashSet<Pet>();
        this.Services = new HashSet<Service>();
    }

    [MaxLength(StoreValidationConstants.NameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(StoreValidationConstants.DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [ForeignKey(nameof(Address))]
    public string AddressId { get; set; } = null!;

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; }

    public virtual ICollection<Pet> Pets { get; set; }

    public virtual ICollection<Service> Services { get; set; }
}