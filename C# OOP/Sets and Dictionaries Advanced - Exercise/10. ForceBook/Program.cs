Dictionary<string, List<string>> forceBook = new Dictionary<string, List<string>>();
string end;
while((end = Console.ReadLine()) != "Lumpawaroo")
{
    if (end.Contains("|"))
    {
        //{forceSide} | {forceUser}
        string[] input = end.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
        if(forceBook.Any(x => x.Value.Contains(input[1])))
        {
            continue;
        }
        if (!forceBook.ContainsKey(input[0]))
        {
            forceBook.Add(input[0], new List<string>());
        }
        if (!forceBook[input[0]].Contains(input[1]))
        {
            forceBook[input[0]].Add(input[1]);
        }
    }
    else if(end.Contains("->"))
    {
        //{forceUser} -> {forceSide}
        string[] input = end.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
        if (!forceBook.ContainsKey(input[1]))
        {
            forceBook.Add(input[1], new List<string>());
        }
        if(forceBook.Any(x => x.Value.Contains(input[0])))
        {
            KeyValuePair<string, List<string>> currentUser = forceBook.Where(x => x.Value.Contains(input[0])).First();
            forceBook[currentUser.Key].Remove(input[0]);
        }
        forceBook[input[1]].Add(input[0]);  
        Console.WriteLine($"{input[0]} joins the {input[1]} side!");
    }
}

foreach(var side in forceBook.Where(x => x.Value.Count() > 0).OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
{
    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count()}");
    foreach (string user in side.Value.OrderBy(x => x))
    {
        Console.WriteLine($"! {user}");
    }
}