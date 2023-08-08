namespace ShallowCopyMemberwiseCloneMethod.Models;

public class Person
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

    public Person Clone()
        => (Person)this.MemberwiseClone();
}