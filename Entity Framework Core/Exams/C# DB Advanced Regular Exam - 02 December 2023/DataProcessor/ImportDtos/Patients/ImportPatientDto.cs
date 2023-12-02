using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos.Patients;

using Common;
using Newtonsoft.Json;

public class ImportPatientDto
{
    [Required]
    [JsonProperty(nameof(FullName))]
    [MinLength(ValidationConstants.PatientFullNameMinLength)]
    [MaxLength(ValidationConstants.PatientFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(AgeGroup))]
    [Range(ValidationConstants.PatientAgeGroupMinRange, ValidationConstants.PatientAgeGroupMaxRange)]
    public int AgeGroup { get; set; }

    [Required]
    [JsonProperty(nameof(Gender))]
    [Range(ValidationConstants.PatientGenderMinRange, ValidationConstants.PatientGenderMaxRange)]
    public int Gender { get; set; }

    [Required]
    [JsonProperty(nameof(Medicines))]
    public int[] Medicines { get; set; } = null!;
}