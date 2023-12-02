namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Newtonsoft.Json;
    using System.Globalization;
    using ExportDtos.Patients;
    using Microsoft.EntityFrameworkCore;
    using Utilities;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            XmlHelper helper = new XmlHelper();

            DateTime parsedDate = ParseDate(date);

            var patients = context
                .Patients
                .ToArray()
                .Where(p => p.PatientsMedicines.Count >= 1 &&
                            p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate >= parsedDate))

                .Select(p => new ExportPatientDto()
                {
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Gender = p.Gender.ToString().ToLower(),
                    Medicines = p.PatientsMedicines
                        .Where(pm => pm.Medicine.ProductionDate >= parsedDate)
                        .OrderByDescending(m => m.Medicine.ExpiryDate)
                        .ThenBy(m => m.Medicine.Price)
                        .Select(pm => new ExportMedicineDto()
                        {
                            Name = pm.Medicine.Name,
                            Price = pm.Medicine.Price.ToString("F2"),
                            Category = pm.Medicine.Category.ToString().ToLower(),
                            ExpiryDate = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                            Producer = pm.Medicine.Producer,
                        })

                        .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.Name)
                .ToArray();

            return helper.Serialize(patients, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context
                .Medicines
                .ToArray()
                .Where(m => (int)m.Category == medicineCategory && m.Pharmacy.IsNonStop == true)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price.ToString("F2"),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber,
                    }
                })
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .ToArray();

            return JsonConvert.SerializeObject(medicines, Formatting.Indented);
        }

        private static DateTime ParseDate(string dateString)
        {
            return DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
}
