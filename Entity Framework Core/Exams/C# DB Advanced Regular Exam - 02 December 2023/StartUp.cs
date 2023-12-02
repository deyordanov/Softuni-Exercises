namespace Medicines
{
    using Medicines.Data;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var context = new MedicinesContext();

            ResetDatabase(context, shouldDropDatabase: false);

            var projectDir = GetProjectDirectory();
            
            ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");
            
            ExportEntities(context, projectDir + @"ExportResults/");
            
            using (var transaction = context.Database.BeginTransaction())
            {
                transaction.Rollback();
            }
        }

        private static void ExportEntities(MedicinesContext context, string exportDir)
        {
            int medicineCategory = 2;
            var ExportMedicinesFromDesiredCategoryInNonStopPharmacies = DataProcessor
                .Serializer.ExportMedicinesFromDesiredCategoryInNonStopPharmacies(context, medicineCategory);
            Console.WriteLine(ExportMedicinesFromDesiredCategoryInNonStopPharmacies);
            File.WriteAllText(exportDir + "Actual Result - ExportMedicinesFromDesiredCategoryInNonStopPharmacies.json", ExportMedicinesFromDesiredCategoryInNonStopPharmacies);

            string date = "2022-01-01";
            var ExportPatientsWithTheirMedicines = DataProcessor
                .Serializer.ExportPatientsWithTheirMedicines(context, date);
            Console.WriteLine(ExportPatientsWithTheirMedicines);
            File.WriteAllText(exportDir + "Actual Result - ExportPatientsWithTheirMedicines.xml", ExportPatientsWithTheirMedicines);
        }

        private static void ImportEntities(MedicinesContext context, string baseDir, string exportDir)
        {
            var pharmacies = DataProcessor.Deserializer
                .ImportPharmacies(context, File.ReadAllText(baseDir + "pharmacies.xml"));

            PrintAndExportEntityToFile(pharmacies, exportDir + "Actual Result - ImportPharmacies.txt");

            var patients = DataProcessor.Deserializer
                .ImportPatients(context, File.ReadAllText(baseDir + "patients.json"));
            
            PrintAndExportEntityToFile(patients, exportDir + "Actual Result - ImportPatients.txt");
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

        private static void ResetDatabase(MedicinesContext context, bool shouldDropDatabase = false)
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
    }
}