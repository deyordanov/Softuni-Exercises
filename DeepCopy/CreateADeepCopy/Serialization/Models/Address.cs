namespace Serialization.Models;

using System.Runtime.Serialization;

[Serializable]
[DataContract]
public class Address
{
    [DataMember]
    public required string Street { get; set; }
    [DataMember]
    public required string City { get; set; }
    [DataMember]
    public required  string Country { get; set; }
}