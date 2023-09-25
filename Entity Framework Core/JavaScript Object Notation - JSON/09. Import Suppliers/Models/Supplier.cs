namespace CarDealer.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Supplier
    {
        public Supplier()
        {
            this.Parts = new List<Part>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsImporter { get; set; }

        public ICollection<Part> Parts { get; set; }
    }
}
