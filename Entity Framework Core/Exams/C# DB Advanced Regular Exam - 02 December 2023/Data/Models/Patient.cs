namespace Medicines.Data.Models;

using System.ComponentModel.DataAnnotations;
using Common;
using Enums;

public class Patient
{
    public Patient()
    {
        this.PatientsMedicines = new HashSet<PatientMedicine>();
    }

    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PatientFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    public AgeGroup AgeGroup { get; set; }

    [Required]
    public Gender Gender { get; set; }

    public ICollection<PatientMedicine> PatientsMedicines  { get; set; }
}