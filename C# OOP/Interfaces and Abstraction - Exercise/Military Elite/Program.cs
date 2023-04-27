using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System.Globalization;

string end;
List<IPrivate> privates = new List<IPrivate>();
List<ISolider> soliders = new List<ISolider>();
while((end = Console.ReadLine()) != "End")
{
    string[] command = end.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string id = command[1];
    string firstName = command[2];
    string lastName = command[3];
    try
    {
        switch (command[0])
        {
            case "Private":
                IPrivate @private = CreatePrivate(id, firstName, lastName, decimal.Parse(command[4]));
                privates.Add(@private);
                soliders.Add(@private);
                break;
            case "LieutenantGeneral":
                soliders.Add(CreateGeneral(id, firstName, lastName, decimal.Parse(command[4]), command));
                break;
            case "Engineer":
                soliders.Add(CreateEngineer(id, firstName, lastName, decimal.Parse(command[4]), command));
                break;
            case "Commando":
                soliders.Add(CreateCommando(id, firstName, lastName, decimal.Parse(command[4]), command));
                break;
            case "Spy":
                soliders.Add(CreateSpy(id, firstName, lastName, int.Parse(command[4])));
                break;
        }
    }
    catch (Exception)
    {
    }
}

foreach(ISolider solider in soliders)
{
    Console.WriteLine(solider.ToString());
}

ISpy CreateSpy(string id, string firstName, string lastName, int codeNumber) => new Spy(id, firstName, lastName, codeNumber);

ICommando CreateCommando(string id, string firstName, string lastName, decimal salary, string[] tokens)
{
    bool isCorpsValid = Enum.TryParse<Corps>(tokens[5], out Corps corps);
    if (!isCorpsValid)
    {
        throw new Exception();
    }
    List<IMission> missions = new List<IMission>();
    for(int i = 6; i < tokens.Length; i++)
    {
        string codeName = tokens[i];
        bool isStateValid = Enum.TryParse<State>(tokens[++i], out State state);
        if (isStateValid)
        {
            IMission mission = new Mission(codeName, state);
            missions.Add(mission);
        }
    }
    return new Commando(id, firstName, lastName, salary, corps, missions);
}

IEngineer CreateEngineer(string id, string firstName, string lastName, decimal salary, string[] tokens)
{
    bool isCorpsValid = Enum.TryParse<Corps>(tokens[5], out Corps corps);
    if (!isCorpsValid)
    {
        throw new Exception();
    }
    List<IRepair> repairs = new List<IRepair>();
    for(int i = 6; i < tokens.Length; i++)
    {
        IRepair repair = new Repair(tokens[i], int.Parse(tokens[++i]));
        repairs.Add(repair);
    }
    return new Engineer(id, firstName, lastName, salary, corps, repairs);
}

ILieutenantGeneral CreateGeneral(string id, string firstName, string lastName, decimal salary, string[] tokens)
{
    List<IPrivate> team = new List<IPrivate>();
    for(int i = 5; i < tokens.Length; i++)
    {
        string currentId = tokens[i];
        if(privates.Any(x => x.Id == currentId))
        {
            team.Add(privates.FirstOrDefault(x => x.Id == currentId));
        }
    }
    return new LieutenantGeneral(id, firstName, lastName, salary, team);
}

IPrivate CreatePrivate(string id, string firstName, string lastName, decimal salary) => new Private(id, firstName, lastName, salary);