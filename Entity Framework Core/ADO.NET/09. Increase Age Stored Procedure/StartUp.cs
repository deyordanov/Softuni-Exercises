namespace _09._Increase_Age_Stored_Procedure
{
    using Microsoft.Data.SqlClient;

    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();

            int minionId = int.Parse(Console.ReadLine());

            await IncrementMinionAge(connection, minionId);
            Console.WriteLine(GetMinionData(connection, minionId).Result);
        }

        static async Task IncrementMinionAge(SqlConnection connection, int minionId)
        {
            SqlCommand command = new SqlCommand(SqlQueries.ExecuteProcedureQuery, connection);
            command.Parameters.AddWithValue("@Id", minionId);

            await command.ExecuteNonQueryAsync();
        }

        static async Task<string> GetMinionData(SqlConnection connection, int minionId)
        {
            SqlCommand command = new SqlCommand(SqlQueries.GetNameAndAgeQuery, connection);
            command.Parameters.AddWithValue("@Id", minionId);

            SqlDataReader reader = await command.ExecuteReaderAsync();

            reader.Read();
            return $"{(string)reader["Name"]} - {(int)reader["Age"]} years old";
        }
    }
}