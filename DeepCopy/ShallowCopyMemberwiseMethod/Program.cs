using ShallowCopyMemberwiseCloneMethod.Models;

Person originalPerson = new Person("Denis", 20, new Address("321", "Sofia", "Bulgaria"));

Person shallowCopyPerson = originalPerson.Clone();

shallowCopyPerson.Name = "Daniel";
shallowCopyPerson.Address.City = "Pernik";

Console.WriteLine($"Original Name: {originalPerson.Name}");
Console.WriteLine($"Copy Name: {shallowCopyPerson.Name}");

Console.WriteLine($"Original City: {originalPerson.Address.City}");
Console.WriteLine($"Copy City: {shallowCopyPerson.Address.City}");

//A shallow copy of the 'original person' has been made, meaning all the reference types inside the original object and the copied one point to the same memory addresses!