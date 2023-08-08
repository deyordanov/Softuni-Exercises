namespace Serialization.Models;

using System.Runtime.Serialization;

[Serializable]
[DataContract]
public class Person
{
    [DataMember]
    public required string Name { get; set; }
    [DataMember]
    public required int Age { get; set; }
    [DataMember]
    public  required Address Address { get; set; }
}