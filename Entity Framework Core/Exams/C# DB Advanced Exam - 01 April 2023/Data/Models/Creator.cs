namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;
using Common;

public class Creator
{
    public Creator()
    {
        this.Boardgames = new HashSet<Boardgame>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.CreatorFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.CreatorLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    public ICollection<Boardgame> Boardgames { get; set; }
}