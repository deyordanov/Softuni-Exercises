namespace DeepCopier.Models;

public class Address : ICloneable
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public object Clone()
        => new Address
        {
            Street = this.Street,
            City = this.City,
            State = this.State
        };   
}