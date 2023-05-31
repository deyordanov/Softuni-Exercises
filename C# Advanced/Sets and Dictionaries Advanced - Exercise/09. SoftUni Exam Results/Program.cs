string end;
Dictionary<string, int> participants = new Dictionary<string, int>();
Dictionary<string, int> submissions = new Dictionary<string, int>();
while((end = Console.ReadLine()) != "exam finished")
{
    //"{username}-{language}-{points}"
    string[] input = end.Split("-", StringSplitOptions.RemoveEmptyEntries);
    if(input.Length == 3)
    {
        if (!submissions.ContainsKey(input[1]))
        {
            submissions.Add(input[1], 0);
        }
        if (!participants.ContainsKey(input[0]))
        {
            participants.Add(input[0], 0);
        }
        if (participants[input[0]] < int.Parse(input[2]))
        {
            participants[input[0]] = int.Parse(input[2]);
        }
        submissions[input[1]]++;
    }
    else
    {
        //"{username}-banned"
        if (participants.ContainsKey(input[0]))
        {
            participants.Remove(input[0]);
        }
    }
}

Console.WriteLine("Results:");
foreach (var participant in participants.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{participant.Key} | {participant.Value}");
}
Console.WriteLine("Submissions:");
foreach (var submission in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{submission.Key} - {submission.Value}");
}