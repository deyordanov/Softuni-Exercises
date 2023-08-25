namespace _08._Increase_Minion_Age
{
    using System.Text;
    using Microsoft.Data.SqlClient;

    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();

            List<int> ids = Console.ReadLine()
                .Split(" ", StringSplitOptions.None)
                .Select(int.Parse)
                .ToList();

            await UpdateAgeAndName(connection, ids);
            Console.WriteLine(GetAllMinionsData(connection).Result);
        }

        static async Task UpdateAgeAndName(SqlConnection connection, List<int> ids)
        {
            SqlCommand command = new SqlCommand(SqlQueries.IncrementAgeAndChangeNameQuery, connection);
            foreach (int id in ids)
            {
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
                command.Parameters.Clear();
            }
        }

        static async Task<string> GetAllMinionsData(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand command = new SqlCommand(SqlQueries.GetNameAndAgeQuery, connection);

            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                sb.AppendLine($"{reader.GetString(0)} {reader.GetInt32(1)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}