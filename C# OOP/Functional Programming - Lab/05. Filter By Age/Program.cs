int n = int.Parse(Console.ReadLine());
List<Person> people = new List<Person>();
for(int i = 0; i < n; i++)
{
    string[] pair = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
    Person person = new Person(pair[0], int.Parse(pair[1]));
    people.Add(person);
}
string condition = Console.ReadLine();
int age = int.Parse(Console.ReadLine());
string format = Console.ReadLine();
Console.WriteLine(string.Join(Environment.NewLine, people.Where(Order(condition, age)).Select(Format(format))));

Func<Person, bool> Order(string condition, int age)
{
    switch (condition)
    {
        case "older":
            return p => p.Age >= age;
        case "younger":
            return p => p.Age < age;
        default:
            return null;
    }
}

Func<Person, string> Format(string format)
{
    switch (format)
    {
        case "name":
            return p => $"{p.Name}";
        case "age":
            return p => $"{p.Age}";
        case "name age":
            return p => $"{p.Name} - {p.Age}";
        default:
            return null;
    }
}

class Person
{
    public Person(string name, int age)
    {
        this.Age = age;
        this.Name = name;
    }
    public int Age { get; private set; }
    public string Name { get; private set; }
}