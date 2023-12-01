using Invoices.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Invoices
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new InvoicesContext();

            ResetDatabase(context, shouldDropDatabase: true);

            var projectDir = GetProjectDirectory();
            
            ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");
            
            ExportEntities(context, projectDir + @"ExportResults/");
            
            using (var transaction = context.Database.BeginTransaction())
            {
                transaction.Rollback();
            }
        }

        private static void ImportEntities(InvoicesContext context, string baseDir, string exportDir)
        {
            var clients =
                DataProcessor.Deserializer.ImportClients(context,
                    File.ReadAllText(baseDir + "clients.xml"));
            PrintAndExportEntityToFile(clients, exportDir + "Actual Result - ImportClients.txt");

            var invoices =
                DataProcessor.Deserializer.ImportInvoices(context,
                    File.ReadAllText(baseDir + "invoices.json"));
            PrintAndExportEntityToFile(invoices, exportDir + "Actual Result - ImportInvoices.txt");
            
            var products =
                DataProcessor.Deserializer.ImportProducts(context,
                    File.ReadAllText(baseDir + "products.json"));
            PrintAndExportEntityToFile(products, exportDir + "Actual Result - ImportProducts.txt");
        }

        private static void ExportEntities(InvoicesContext context, string exportDir)
        {
            DateTime date = DateTime.ParseExact("01/12/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var exportClientsWithTheirInvoices = DataProcessor.Serializer.ExportClientsWithTheirInvoices(context, date);
            Console.WriteLine(exportClientsWithTheirInvoices);
            File.WriteAllText(exportDir + "Actual Result - ExportClientsWithTheirInvoices.xml",
                exportClientsWithTheirInvoices);

            var nameLength = 11;
            var exportProductsWithMostClients =
                DataProcessor.Serializer.ExportProductsWithMostClients(context, nameLength);
            Console.WriteLine(exportProductsWithMostClients);
            File.WriteAllText(exportDir + "Actual Result - ExportProductsWithMostClients.json",
                exportProductsWithMostClients);
        }

        private static void ResetDatabase(InvoicesContext context, bool shouldDropDatabase = false)
        {
            if (shouldDropDatabase)
            {
                context.Database.EnsureDeleted();
            }

            if (context.Database.EnsureCreated())
            {
                return;
            }

            var disableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
            context.Database.ExecuteSqlRaw(disableIntegrityChecksQuery); 

            var deleteRowsQuery = "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
            context.Database.ExecuteSqlRaw(deleteRowsQuery);

            var enableIntegrityChecksQuery =
                "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
            context.Database.ExecuteSqlRaw(enableIntegrityChecksQuery);

            var reseedQuery =
                "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED, 0)'";
            context.Database.ExecuteSqlRaw(reseedQuery);
        }

        private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
        {
            Console.WriteLine(entityOutput);
            File.WriteAllText(outputPath, entityOutput.TrimEnd());
        }

        private static string GetProjectDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryName = Path.GetFileName(currentDirectory);
            var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

            return relativePath;
        }
    }
}