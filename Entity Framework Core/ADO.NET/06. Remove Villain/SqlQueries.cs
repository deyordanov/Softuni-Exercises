namespace _06._Remove_Villain;

public class SqlQueries
{
    public const string GetVillainNameByIdQuery = @"SELECT Name
                                                      FROM Villains
                                                     WHERE Id = @villainId";

    public const string DeleteFromMinionsAndVillainsTableQuery = @"DELETE
                                                                     FROM MinionsVillains
                                                                    WHERE VillainId = @villainId";

    public const string DeleteFromVillainsTableQuery = @"DELETE
                                                           FROM Villains
                                                          WHERE Id = @villainId";
}