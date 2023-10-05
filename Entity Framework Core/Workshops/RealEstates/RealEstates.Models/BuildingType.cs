namespace RealEstates.Models;

using System.ComponentModel.DataAnnotations;

public class BuildingType
{
    public BuildingType()
    {
        this.Properties = new HashSet<Property>();
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Property> Properties { get; set; }
}