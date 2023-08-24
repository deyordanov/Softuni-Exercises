namespace _03._Minion_Names
{
    using System.Text;
    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();
            int villainId = int.Parse(Console.ReadLine());
            
            Console.WriteLine(GetAllMinionsByVillainId(connection, villainId).Result);
        }

        static async Task<string> GetAllMinionsByVillainId(SqlConnection connection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand getVillainName = new SqlCommand(SqlQueries.GetVillainNameById, connection);
            getVillainName.Parameters.AddWithValue("@Id", villainId);

            string? villainName = await getVillainName.ExecuteScalarAsync() as string;
            if (villainName == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }
            sb.AppendLine($"Villain: {villainName}");

            SqlCommand getMinions = new SqlCommand(SqlQueries.GetMinionsByVillainIdQuery, connection);
            getMinions.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader reader = await getMinions.ExecuteReaderAsync();
            if (!reader.HasRows)
            {
                 sb.AppendLine("(no minions)");
            }

            while (reader.Read())
            {
                long row = reader.GetInt64(0);
                string name = reader.GetString(1);
                int age = reader.GetInt32(2);
                sb.AppendLine($"{row}. {name} {age}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}