namespace SeminarHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.Constants.ValidationConstants.Category;

public class Category
{
    public Category()
    {
        this.Seminars = new List<Seminar>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(CategoryNameMaxLength)]
    public string Name { get; set; } = string.Empty;

    public IList<Seminar> Seminars { get; set; }
}