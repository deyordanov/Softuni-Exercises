namespace PetsStore.Data.Models;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;
using Data.Common.Models;

public class Product : BaseDeletableModel<string>
{
    public Product()
    {
        this.Id = Guid.NewGuid().ToString();

        this.Stores = new HashSet<Store>();
        this.Orders = new HashSet<Order>();
    }

    [MaxLength(ProductValidationConstants.NameMaxLength)]
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string ImageURL { get; set; } = null!;

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<Store> Stores { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}