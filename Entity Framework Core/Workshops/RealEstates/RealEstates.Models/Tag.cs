namespace RealEstates.Models;

using System.ComponentModel.DataAnnotations;

public class Tag
{
    public Tag()
    {
        this.Properties = new HashSet<Property>();
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? Importance { get; set; }
    public virtual ICollection<Property> Properties { get; set; }
}