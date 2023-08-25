using _06._Remove_Villain.Exceptions;

namespace _06._Remove_Villain
{
    using System.Text;
    using Microsoft.Data.SqlClient;

    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();

            try
            {
                int villainId = int.Parse(Console.ReadLine());
                string villainName = await GetVillainNameById(connection, villainId);
                int affectedMinions = await DeleteFromMinionsAndVillainsTable(connection, villainId);
                await DeleteFromVillainsTable(connection, villainId);

                sb.AppendLine($"{villainName} was deleted.");
                sb.AppendLine($"{affectedMinions} minions were released.");
            }
            catch (VillainDoesNotExistException vdnee)
            {
                sb.AppendLine(vdnee.Message);
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        static async Task<string> GetVillainNameById(SqlConnection connection, int villainId)
        {
            SqlCommand command = new SqlCommand(SqlQueries.GetVillainNameByIdQuery, connection);
            command.Parameters.AddWithValue("@villainId", villainId);

            string? villainName = await command.ExecuteScalarAsync() as string;
            if (villainName == null)
            {
                throw new VillainDoesNotExistException();
            }

            return villainName;
        }

        static async Task<int> DeleteFromMinionsAndVillainsTable(SqlConnection connection, int villainId)
        {
            SqlCommand command = new SqlCommand(SqlQueries.DeleteFromMinionsAndVillainsTableQuery, connection);
            command.Parameters.AddWithValue("@villainId", villainId);

            int affectedMinions = await command.ExecuteNonQueryAsync();

            return affectedMinions;
        }

        static async Task DeleteFromVillainsTable(SqlConnection connection, int villainId)
        {
            SqlCommand command = new SqlCommand(SqlQueries.DeleteFromVillainsTableQuery, connection);
            command.Parameters.AddWithValue("@villainId", villainId);

            await command.ExecuteNonQueryAsync();
        }
    }
}