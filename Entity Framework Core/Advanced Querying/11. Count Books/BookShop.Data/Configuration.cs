namespace BookShop.Data
{
    internal class Configuration
    {
        internal static string ConnectionString
            => @"Server=localhost,1433;Database=MinionsDB;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True";
    }
}
