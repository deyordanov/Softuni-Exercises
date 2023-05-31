List<string> people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
List<string> filters = new List<string>();
string end;
while((end = Console.ReadLine()) != "Print")
{
    //{command;filter type;filter parameter}"
    string[] command = end.Split(";", StringSplitOptions.RemoveEmptyEntries);
    if (command[0] == "Add filter")
    {
        filters.Add($"{command[1]}-{command[2]}");
    }
    else
    {
        filters.Remove($"{command[1]}-{command[2]}");
    }
}

foreach(string filter in filters)
{
    string[] currentFilter = filter.Split("-");
    people = people.FindAll(GetPredicate(currentFilter[0], currentFilter[1]));
}

Console.WriteLine(string.Join(" ", people));

Predicate<string> GetPredicate(string filter, string value)
{
    switch (filter)
    {
        case "Starts with":
            return n => !n.StartsWith(value);
        case "Ends with":
            return n => !n.EndsWith(value);
        case "Length":
            return n => !(n.Length == int.Parse(value));
        case "Contains":
            return n => !n.Contains(value);
        default:
            return null;
    }
}