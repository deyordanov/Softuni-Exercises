namespace Medicines.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Enums;

public class Medicine
{
    public Medicine()
    {
        this.PatientsMedicines = new HashSet<PatientMedicine>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.MedicineNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public Category Category { get; set; }

    [Required]
    public DateTime ProductionDate { get; set; }

    [Required]
    public DateTime ExpiryDate  { get; set; }

    [Required]
    [MaxLength(ValidationConstants.MedicineProducerMaxLength)]
    public string Producer { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Pharmacy))]
    public int PharmacyId { get; set; }

    public Pharmacy Pharmacy { get; set; } = null!;

    public ICollection<PatientMedicine> PatientsMedicines { get; set; }
}