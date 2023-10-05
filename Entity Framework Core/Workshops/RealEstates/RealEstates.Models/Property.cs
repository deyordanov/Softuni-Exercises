namespace RealEstates.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Property
    {
        public Property()
        {
            this.Tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }
        public int Size { get; set; }
        public int? YardSize { get; set; }
        public byte? Floor { get; set; }
        public byte? TotalFloors { get; set; }
        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }
        public virtual District District { get; set; } = null!;
        public int? Year { get; set; }
        [ForeignKey(nameof(PropertyType))]
        public int PropertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; } = null!;
        [ForeignKey(nameof(BuildingType))]
        public int BuildingTypeId { get; set; }
        public virtual BuildingType BuildingType { get; set; } = null!;
        public int? Price { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}