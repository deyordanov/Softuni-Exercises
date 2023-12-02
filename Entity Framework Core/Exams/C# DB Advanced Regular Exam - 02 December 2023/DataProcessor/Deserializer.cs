namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using ImportDtos.Pharmacies;
    using Utilities;
    using System.Globalization;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDtos.Patients;
    using Microsoft.Data.SqlClient.Server;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPatientDto[] importedDtos =  JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString)!;

            ICollection<Patient> validPatients = new HashSet<Patient>();

            ICollection<int> medicineIds = context.Medicines.Select(m => m.Id).ToArray();

            foreach (ImportPatientDto patientDto in importedDtos)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient()
                {
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    FullName = patientDto.FullName,
                    Gender = (Gender)patientDto.Gender,
                };

                foreach (int medicineId in patientDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(pm => pm.MedicineId == medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!medicineIds.Contains(medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        MedicineId = medicineId,
                        Medicine = context.Medicines.Find(medicineId)!,
                    };

                    patient.PatientsMedicines.Add(patientMedicine);
                }

                validPatients.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(validPatients);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlHelper helper = new XmlHelper();

            ImportPharmacyDto[] importedDtos = helper.Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            ICollection<Pharmacy> validPharmacies = new HashSet<Pharmacy>();

            foreach (ImportPharmacyDto pharmacyDto in importedDtos)
            {
                if (!IsValid(pharmacyDto)) 
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (pharmacyDto.IsNonStop != "true" && pharmacyDto.IsNonStop != "false")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy()
                {
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber,
                    IsNonStop = bool.Parse(pharmacyDto.IsNonStop),
                };

                foreach (ImportMedicineDto medicineDto in pharmacyDto.Medicines)
                {
                    if (!IsValid(medicineDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime productionDate = ParseDate(medicineDto.ProductionDate);
                    DateTime expiryDate = ParseDate(medicineDto.ExpiryDate);

                    if (productionDate >= expiryDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (pharmacy.Medicines.Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine medicine = new Medicine()
                    {
                        ProductionDate = productionDate,
                        ExpiryDate = expiryDate,
                        Name = medicineDto.Name,
                        Price = medicineDto.Price,
                        Producer = medicineDto.Producer,
                        Category = (Category)medicineDto.Category
                    };

                    pharmacy.Medicines.Add(medicine);
                }

                validPharmacies.Add(pharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static DateTime ParseDate(string dateString)
        {
            return DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
