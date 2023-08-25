namespace _04._Add_Minion;

public static class SqlQueries
{
    public const string GetTownIdByNameQuery = @"SELECT Id
                                            FROM Towns
                                            WHERE Name = @townName";

    public const string CreateNewTownQuery = @"INSERT INTO Towns (Name)
                                                    VALUES (@townName)";

    public const string GetVillainIdByNameQuery = @"SELECT Id
                                                    FROM Villains
                                                    WHERE Name = @Name";

    public const string CreateNewVillainQuery = @"INSERT INTO Villains (Name, EvilnessFactorId)
                                                                       VALUES (@villainName, 4)";

    public const string GetMinionIdByNameQuery = @"SELECT Id
                                                    FROM Minions
                                                    WHERE Name = @Name";

    public const string CreateNewMinionQuery = @"INSERT INTO Minions (Name, Age, TownId)
                                                              VALUES (@name, @age, @townId)";

    public const string AssignMinionToVillainQuery = @"INSERT INTO MinionsVillains (MinionId, VillainId)
                                                                            VALUES (@minionId, @villainId)";
}