namespace ShallowCopyMemberwiseCloneMethod.Models;

public class Address : ICloneable
{
    public Address(Address original)
    {
        this.Street = original.Street;
        this.City = original.City;
        this.Country = original.Country;
    }
    public Address(string street, string city, string country)
    {
        Street = street;
        City = city;
        Country = country;
    }
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public object Clone()
        => new Address(this.Street, this.City, this.Country);
}