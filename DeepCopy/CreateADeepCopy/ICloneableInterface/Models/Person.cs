namespace ShallowCopyMemberwiseCloneMethod.Models;

public class Person : ICloneable
{
    public Person(string name, int age, Address address)
    {
        Name = name;
        Age = age;
        Address = address;
    }
    public string Name { get; set; }
    public int Age { get; set; }
    public  Address Address { get; set; }

    public object Clone()
        => new Person(this.Name, this.Age, (Address)this.Address.Clone());
}