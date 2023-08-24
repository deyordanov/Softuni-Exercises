namespace P02.VillainNames
{
    using System.Text;
    using _02._Villain_Names;
    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection sqlConnection =
                new SqlConnection(Config.ConnectionString);
            await sqlConnection.OpenAsync();

            Console.WriteLine(GetAllVillainsWithTheirMinionsAsync(sqlConnection).Result);
        }

        static async Task<string> GetAllVillainsWithTheirMinionsAsync(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand sqlCommand =
                new SqlCommand(SqlQueries.GetAllVillainsQuery, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            while (reader.Read())
            {
                string villainName = reader.GetString(0);
                int minionsCount = reader.GetInt32(1);

                sb.AppendLine($"{villainName} – {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}