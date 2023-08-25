namespace _08._Increase_Minion_Age;

public class SqlQueries
{
    public const string IncrementAgeAndChangeNameQuery = @"UPDATE Minions
                                                SET Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)),
                                                    Age += 1
                                                WHERE Id = @Id";

    public const string GetNameAndAgeQuery = @"SELECT Name, Age
                                                 FROM Minions";
}