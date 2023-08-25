namespace _04._Change_Town_Names_Casing
{
    using Microsoft.Data.SqlClient;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();

            string countryName = Console.ReadLine();

            await UpdateTownNamesToUpperCase(connection, countryName);
        }

        static async Task UpdateTownNamesToUpperCase(SqlConnection connection, string countryName)
        {
            SqlCommand updateName = new SqlCommand(SqlQueries.UpdateTownNameQuery, connection);
            updateName.Parameters.AddWithValue("@countryName", countryName);

            await updateName.ExecuteNonQueryAsync();

            var rowsAffected = await updateName.ExecuteNonQueryAsync();
            if (rowsAffected == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            SqlCommand getNames = new SqlCommand(SqlQueries.GetTownNamesQuery, connection);
            getNames.Parameters.AddWithValue("@countryName", countryName);

            SqlDataReader reader = await getNames.ExecuteReaderAsync();

            List<string> townNames = new List<string>();
            while (reader.Read())
            {
                townNames.Add(reader.GetString(0));
            }

            Console.WriteLine($"{rowsAffected} town names were affected.");
            Console.WriteLine($"[{string.Join(", ", townNames)}]");
        }
    }
}