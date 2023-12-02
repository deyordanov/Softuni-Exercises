namespace Medicines.Data.Models;

using System.ComponentModel.DataAnnotations;
using Common;

public class Pharmacy
{
    public Pharmacy()
    {
        this.Medicines = new HashSet<Medicine>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PharmacyNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.PharmacyPhoneNumberMaxLength)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public bool IsNonStop { get; set; }

    public ICollection<Medicine> Medicines { get; set; }
}