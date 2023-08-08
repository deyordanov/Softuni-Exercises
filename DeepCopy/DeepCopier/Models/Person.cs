namespace DeepCopier.Models;

public class Person : ICloneable
{
    public required string Name { get; set; }
    public required int Age { get; set; }
    public required Address Address { get; set; }

    public Person ShallowCopy() => (Person)this.MemberwiseClone();

    public object Clone()
        => new Person
        {
            Name = this.Name,
            Age = this.Age,
            Address = (Address)this.Address.Clone(),
        };
}