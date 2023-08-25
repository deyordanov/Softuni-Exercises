namespace _04._Add_Minion
{
    using System.Text;
    using Microsoft.Data.SqlClient;

    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            await connection.OpenAsync();

            string[] minionArgs = Console.ReadLine().Split(" ");
            string villainName = Console.ReadLine().Split(" ")[1];

            string minionName = minionArgs[1];
            int minionAge = int.Parse(minionArgs[2]);
            string townName = minionArgs[3];

            StringBuilder sb = new StringBuilder();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                int townId 
                    = await GetTownIdByName(connection, transaction, sb, townName);
                int villainId 
                    = await GetVillainIdByName(connection,transaction, sb, villainName);
                int minionId 
                    = await GetMinionIdByName(connection, transaction, minionName, minionAge, townId,villainName);

                await AssignMinionToVillain(connection, transaction, villainId, minionId);
                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                sb.AppendLine($"Transaction failed!");
                transaction.Rollback();
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        static async Task<int> GetTownIdByName(SqlConnection connection,SqlTransaction transaction, StringBuilder sb, string townName)
        {
            SqlCommand getId = new SqlCommand(SqlQueries.GetTownIdByNameQuery, connection, transaction);
            getId.Parameters.AddWithValue("@townName", townName);

            int? townId = (int?)await getId.ExecuteScalarAsync();
            if (townId == null)
            {
                SqlCommand insertTown = new SqlCommand(SqlQueries.CreateNewTownQuery, connection, transaction);
                insertTown.Parameters.AddWithValue("@townName", townName);

                await insertTown.ExecuteNonQueryAsync();

                townId = (int?)await getId.ExecuteScalarAsync();

                sb.AppendLine($"Town {townName} was added to the database.");
            }

            return townId.Value;
        }

        static async Task<int> GetVillainIdByName(SqlConnection connection, SqlTransaction transaction,
            StringBuilder sb, string villainName)
        {
            SqlCommand getId = new SqlCommand(SqlQueries.GetVillainIdByNameQuery, connection, transaction);
            getId.Parameters.AddWithValue("@Name", villainName);

            int? villainId = (int?)await getId.ExecuteScalarAsync();
            if (villainId == null)
            {
                SqlCommand insertVillain = new SqlCommand(SqlQueries.CreateNewVillainQuery, connection, transaction);
                insertVillain.Parameters.AddWithValue("@villainName", villainName);

                await insertVillain.ExecuteNonQueryAsync();

                villainId = (int?)await getId.ExecuteScalarAsync();

                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId.Value;
        }

        static async Task<int> GetMinionIdByName(SqlConnection connection, SqlTransaction transaction, 
            string minionName, int minionAge, int townId, string villainName)
        {
            SqlCommand getId = new SqlCommand(SqlQueries.GetMinionIdByNameQuery, connection, transaction);
            getId.Parameters.AddWithValue("@Name", minionName);

            int? minionId = (int?) await getId.ExecuteScalarAsync();
            if (minionId == null)
            {
                SqlCommand insertMinion = new SqlCommand(SqlQueries.CreateNewMinionQuery, connection, transaction);
                insertMinion.Parameters.AddWithValue("@name", minionName);
                insertMinion.Parameters.AddWithValue("@age", minionAge);
                insertMinion.Parameters.AddWithValue("@townId", townId);

                await insertMinion.ExecuteNonQueryAsync();

                minionId = (int?) await getId.ExecuteScalarAsync();
            }

            return minionId.Value;
        }

        static async Task AssignMinionToVillain(SqlConnection connection, SqlTransaction transaction, int villainId, int minionId)
        {
            SqlCommand assignMinion = new SqlCommand(SqlQueries.AssignMinionToVillainQuery, connection, transaction);
            assignMinion.Parameters.AddWithValue("@minionId", minionId);
            assignMinion.Parameters.AddWithValue("@villainId", villainId);

            await assignMinion.ExecuteNonQueryAsync();
        }
    }
}