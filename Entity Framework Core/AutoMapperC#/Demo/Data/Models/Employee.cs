namespace Demo.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [ForeignKey(nameof(Address))]
    public int AddressId { get; set; }

    public Address Address { get; set; } = null!;
}