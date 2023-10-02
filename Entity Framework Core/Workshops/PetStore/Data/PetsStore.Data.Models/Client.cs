namespace PetsStore.Data.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetsStore.Data.Models.Common;

public class Client : ApplicationUser
{
    public Client()
    {
        this.PaymentCards = new HashSet<CardInfo>();
        this.Pets = new HashSet<Pet>();
        this.Orders = new HashSet<Order>();
    }

    [MaxLength(ClientValidationConstants.FirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [MaxLength(ClientValidationConstants.LastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [ForeignKey(nameof(Client))]
    public string AddressId { get; set; }

    public virtual Address Address { get; set; }

    [ForeignKey(nameof(ClientCard))]
    public string ClientCardId { get; set; }

    public virtual ClientCard ClientCard { get; set; }

    public virtual ICollection<CardInfo> PaymentCards { get; set; }

    public virtual ICollection<Pet> Pets { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}