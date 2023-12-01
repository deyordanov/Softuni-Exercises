namespace Invoices.Data
{
    public static class Configuration
    {
        public static string ConnectionString =
            @"Server=localhost,1433;Database=Invoices;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True";
    }
}