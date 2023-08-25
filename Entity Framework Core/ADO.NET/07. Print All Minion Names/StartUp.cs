namespace _07._Print_All_Minion_Names
{
    using System.Text;
    using System.Xml;
    using Microsoft.Data.SqlClient;

    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();

            Console.WriteLine(GetAndReorderMinionNames(connection).Result);
        }

        static async Task<string> GetAndReorderMinionNames(SqlConnection connection)
        {
            StringBuilder sb =new StringBuilder();

            SqlCommand command = new SqlCommand(SqlQueries.GetMinionNamesQuery, connection);
            SqlDataReader reader = await command.ExecuteReaderAsync();
            List<string> minions = new List<string>();
            while (reader.Read())
            {
                minions.Add(reader.GetString(0));
            }

            for (int i = 0; i < minions.Count / 2; i++)
            {
                sb.AppendLine(minions[i]);
                sb.AppendLine(minions[minions.Count - 1 - i]);
            }

            if (minions.Count % 2 != 0)
            {
                sb.AppendLine(minions[minions.Count / 2]);
            }

            return sb.ToString().TrimEnd();
        }
    }
}