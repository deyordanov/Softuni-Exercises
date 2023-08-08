using ShallowCopyMemberwiseCloneMethod.Models;

Person originalPerson = new Person("Denis", 20, new Address("321", "Sofia", "Bulgaria"));

Person deepCopyPerson = new Person(originalPerson);

deepCopyPerson.Name = "Daniel";
deepCopyPerson.Address.City = "Pernik";

Console.WriteLine($"Original Name: {originalPerson.Name}");
Console.WriteLine($"Copy Name: {deepCopyPerson.Name}");

Console.WriteLine($"Original City: {originalPerson.Address.City}");
Console.WriteLine($"Copy City: {deepCopyPerson.Address.City}");

//A deep copy has been made from the 'original person', but this way of creating a deep copy suffers from the same drawbacks as the one where we implement the ICloneable interface.