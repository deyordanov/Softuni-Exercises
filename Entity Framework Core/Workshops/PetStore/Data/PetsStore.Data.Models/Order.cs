namespace PetsStore.Data.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using PetsStore.Data.Common.Models;

public class Order : BaseDeletableModel<string>
{
    public Order()
    {
        this.Id = Guid.NewGuid().ToString();

        this.Products = new HashSet<Product>();
        this.Services = new HashSet<Service>();
    }

    public DateTime Date { get; set; }

    public decimal TotalPrice { get; set; }

    [ForeignKey(nameof(DeliveryType))]
    public int DeliveryTypeId { get; set; }

    public virtual DeliveryType DeliveryType { get; set; } = null!;

    public string ClientId { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; }

    public virtual ICollection<Service> Services { get; set; }
}