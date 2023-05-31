Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();
string end;
while((end = Console.ReadLine()) != "Statistics")
{
    string[] input = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    switch (input[1])
    {
        case "joined":
            if (!vloggers.ContainsKey(input[0]))
            {
                vloggers.Add(input[0], new Dictionary<string, HashSet<string>>());
                vloggers[input[0]].Add("followers", new HashSet<string>());
                vloggers[input[0]].Add("following", new HashSet<string>());
            }
            break;
        case "followed":
            if (vloggers.ContainsKey(input[0]) && vloggers.ContainsKey(input[2]) && !vloggers[input[0]]["following"].Contains(input[2]) && input[0] != input[2])
            {
                vloggers[input[2]]["followers"].Add(input[0]);
                vloggers[input[0]]["following"].Add(input[2]);
            }
            break;
    }
}

int index = 1;
Console.WriteLine($"The V-Logger has a total of {vloggers.Keys.Count()} vloggers in its logs.");
foreach (var vlogger in vloggers.OrderByDescending(x => x.Value["followers"].Count()).ThenBy(x => x.Value["following"].Count()))
{
    Console.WriteLine($"{index++}. {vlogger.Key} : {vlogger.Value["followers"].Count()} followers, {vlogger.Value["following"].Count()} following");
    if (index == 2)
    {
        Console.WriteLine(string.Join(Environment.NewLine, vlogger.Value["followers"].OrderBy(x => x).Select(x => $"*  {x}")));
    }
}