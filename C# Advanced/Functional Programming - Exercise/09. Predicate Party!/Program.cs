using System.Linq;

List<string> people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
string party;
while((party = Console.ReadLine()) != "Party!")
{
    string[] input = party.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (input[0] == "Remove")
    {
        people.RemoveAll(GetPredicate(input[1], input[2]));
    }
    else
    {
        List<string> peopleToDouble = people.FindAll(GetPredicate(input[1], input[2]));
        foreach(string person in peopleToDouble)
        {
            int index = people.IndexOf(person);
            people.Insert(index, person);
        }
    }
}

string output = people.Count == 0
    ? "Nobody is going to the party!"
    : $"{string.Join(", ", people)} are going to the party!";
Console.WriteLine(output);

Predicate<string> GetPredicate(string command, string value)
{
    switch (command)
    {
        case "StartsWith":
            return n => n.StartsWith(value);
        case "EndsWith":
            return n => n.EndsWith(value);  
        case "Length":
            return n => n.Length == int.Parse(value);
        default:
            return null;
    }
}