namespace PetsStore.Data.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetsStore.Data.Common.Models;
using Common;

public class Address : BaseDeletableModel<string>
{
    public Address()
    {
        this.Id = Guid.NewGuid().ToString();

        this.Clients = new HashSet<Client>();
    }

    [MaxLength(AddressValidationConstants.AddressTextMaxLength)]
    public string AddressText { get; set; } = null!;

    [MaxLength(AddressValidationConstants.TownNameMaxLength)]
    public string TownName { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; }

    [ForeignKey(nameof(Store))]
    public string StoreId { get; set; }

    public virtual Store Store { get; set; }
}