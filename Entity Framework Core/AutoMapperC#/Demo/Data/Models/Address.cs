namespace Demo.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Address
{
    public Address()
    {
        this.Residents = new HashSet<Employee>();
    }
    [Key]
    public int Id { get; set; }
    public string Street { get; set; } = null!;
    public int ZipCode { get; set; }
    public ICollection<Employee> Residents { get; set; }
}