namespace ShallowCopyMemberwiseCloneMethod.Models;

public class Address
{
    public Address(string street, string city, string country)
    {
        Street = street;
        City = city;
        Country = country;
    }
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}