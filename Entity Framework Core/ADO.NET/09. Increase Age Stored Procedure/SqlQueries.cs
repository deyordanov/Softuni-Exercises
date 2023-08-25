namespace _09._Increase_Age_Stored_Procedure;

public class SqlQueries
{
    public const string ExecuteProcedureQuery = @"EXECUTE usp_GetOlder @Id";

    public const string GetNameAndAgeQuery = @"SELECT [Name], Age
                                                 FROM Minions
                                                WHERE Id = @Id";
}