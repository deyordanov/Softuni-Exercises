namespace RealEstates.Models;

public class District
{
    public District()
    {
        this.Properties = new HashSet<Property>();
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Property> Properties { get; set; }
}