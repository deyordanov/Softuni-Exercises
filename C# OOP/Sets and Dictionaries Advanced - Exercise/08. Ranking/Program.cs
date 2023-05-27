string contest;
Dictionary<string, string> contests = new Dictionary<string, string>();
while((contest = Console.ReadLine()) != "end of contests")
{
    string[] input = contest.Split(":", StringSplitOptions.RemoveEmptyEntries);
    if (!contests.ContainsKey(input[0]))
    {
        contests.Add(input[0], input[1]);
    }
}

string end;
Dictionary<string, Dictionary<string, int>> participants = new Dictionary<string, Dictionary<string, int>>();
while((end = Console.ReadLine()) != "end of submissions")
{
    //"{contest}=>{password}=>{username}=>{points}"
    string[] input = end.Split("=>", StringSplitOptions.RemoveEmptyEntries);
    if (contests.ContainsKey(input[0]) && contests[input[0]] == input[1])
    {
        if (!participants.ContainsKey(input[2]))
        {
            participants.Add(input[2], new Dictionary<string, int>());
        }
        if (participants[input[2]].ContainsKey(input[0]) && participants[input[2]][input[0]] < int.Parse(input[3]))
        {
            participants[input[2]][input[0]] = int.Parse(input[3]);
        }
        else if(!participants[input[2]].ContainsKey(input[0]))
        {
            participants[input[2]].Add(input[0], int.Parse(input[3]));
        }
    }
}

int points = int.MinValue;
string name = string.Empty;
foreach(var participant  in participants)
{
    if(participant.Value.Values.Sum(x => x) > points)
    {
        points = participant.Value.Values.Sum(x => x);
        name = participant.Key;
    }
}
Console.WriteLine($"Best candidate is {name} with total {points} points.");
Console.WriteLine("Ranking:");
foreach (var participant in participants.OrderBy(x => x.Key))
{
    Console.WriteLine(participant.Key);
    foreach (var pair in participant.Value.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {pair.Key} -> {pair.Value}");
    }
}