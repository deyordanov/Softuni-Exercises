using ShallowCopyMemberwiseCloneMethod.Models;

Person originalPerson = new Person("Denis", 20, new Address("321", "Sofia", "Bulgaria"));

Person deepCopyPerson = (Person)originalPerson.Clone();

deepCopyPerson.Name = "Daniel";
deepCopyPerson.Address.City = "Pernik";

Console.WriteLine($"Original Name: {originalPerson.Name}");
Console.WriteLine($"Copy Name: {deepCopyPerson.Name}");

Console.WriteLine($"Original City: {originalPerson.Address.City}");
Console.WriteLine($"Copy City: {deepCopyPerson.Address.City}");

//A deep copy has been made of the 'original person', reference types don't point to the same addresses anymore. This is the easiest way to make a deep copy, but also one of the most unreliable ones. After implementing the ICloneable interface, we are given a method Clone(), but it is not specified whether it creates a deep or a shallow copy. Different classes have their own way of implementation, that is why we cannot depend on ICloneable to always create deep copies.