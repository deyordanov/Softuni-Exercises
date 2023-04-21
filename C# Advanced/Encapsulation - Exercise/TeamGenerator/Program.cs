using TeamGenerator;
List<Team> teams = new List<Team>();
string end;
while((end = Console.ReadLine()) != "END")
{
    string[] tokens = end.Split(";");
    switch (tokens[0])
    {
        case "Add":
            AddPlayer(tokens[1], teams, tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));
            break;
        case "Remove":
            RemovePlayer(tokens[1], teams, tokens[2]);
            break;
        case "Rating":
            Rating(tokens[1], teams);
            break;
        case "Team":
            AddTeam(tokens[1], teams);
            break;
    }
}
static void AddPlayer(string teamName, List<Team> teams, string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);
    if(team == null)
    {
        Console.WriteLine($"Team {teamName} does not exist.");

        return;
    }

    try
    {
        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
        team.AddPlayer(player);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void RemovePlayer(string teamName, List<Team> teams, string playerName)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);
    if (team == null)
    {
        Console.WriteLine($"Team {teamName} does not exist.");

        return;
    }

    try
    {
        team.RemovePlayer(playerName);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void Rating(string teamName, List<Team> teams)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);
    if (team == null)
    {
        Console.WriteLine($"Team {teamName} does not exist.");

        return;
    }
    Console.WriteLine($"{team.Name} - {team.Rating}");
}

static void AddTeam(string teamName, List<Team> teams)
{
    try
    {
        Team team = new Team(teamName);
        teams.Add(team);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}