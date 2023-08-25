namespace _04._Change_Town_Names_Casing;

public class SqlQueries
{
    public const string UpdateTownNameQuery = @"UPDATE Towns
                            SET Name = UPPER(Name)
                            WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

    public const string GetTownNamesQuery = @"SELECT t.Name
                                            FROM Towns as t
                                                     JOIN Countries AS c ON c.Id = t.CountryCode
                                            WHERE c.Name = @countryName";
}