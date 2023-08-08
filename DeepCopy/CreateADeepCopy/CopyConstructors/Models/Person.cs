namespace ShallowCopyMemberwiseCloneMethod.Models;

public class Person : ICloneable
{
    public Person(Person original)
    {
        this.Name = original.Name;
        this.Age = original.Age;
        this.Address = new Address(original.Address);
    }
    public Person(string name, int age, Address address)
    {
        this.Name = name;
        this.Age = age;
        this.Address = address;
    }
    public string Name { get; set; }
    public int Age { get; set; }
    public  Address Address { get; set; }

    public object Clone()
        => new Person(this.Name, this.Age, (Address)this.Address.Clone());
}