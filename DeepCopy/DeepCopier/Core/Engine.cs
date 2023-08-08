namespace DeepCopy.Core;

using Contracts;
using DeepCopier.Models;
using IO.Contracts;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        //Creating a shallow copy

        Person originalPerson = new Person
        {
            Name = "Denis",
            Age = 20,
            Address = new Address
            {
                Street = "432",
                City = "Anywhere",
                State = "Everywhere"
            }
        };

        Person shallowCopyOfOriginalPerson = originalPerson.ShallowCopy();

        shallowCopyOfOriginalPerson.Name = "Daniel";
        shallowCopyOfOriginalPerson.Address.City = "Delware";

        this.writer.WriteLine($"Original Name: {originalPerson.Name}");
        this.writer.WriteLine($"Shallow Copy Name: {shallowCopyOfOriginalPerson.Name}");

        this.writer.WriteLine($"Original City: {originalPerson.Address.City}");
        this.writer.WriteLine($"Shallow Copy City: {originalPerson.Address.City}");

        //Reference types still point to the same memory address after being copied, unlike deep copies.

        this.writer.WriteLine(new string('-', 40));

        //Creating a deep copy by implementing the ICloneable interface - easiest way
        //The main problem with this approach is that the interface provides a Clone() method, but does not specify whether it creates a deep or a shallow copy. Different classes have their own way of implementation, that is why we cannot depend on ICloneable to always create deep copies.

        Person clonedPerson = (Person)originalPerson.Clone();
        clonedPerson.Name = "Gosho";
        clonedPerson.Address.City = "Sofia";

        this.writer.WriteLine($"Original Name: {originalPerson.Name}");
        this.writer.WriteLine($"Cloned Name: {clonedPerson.Name}");

        this.writer.WriteLine($"Original City: {originalPerson.Address.City}");
        this.writer.WriteLine($"Cloned City: {clonedPerson.Address.City}");

        //A deep copy of the original person has been made, reference types don't point to the same memory address anymore
    }
}