namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.ProductsSold = new HashSet<Product>();
            this.ProductsBought = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int? Age { get; set; }

        public ICollection<Product> ProductsSold { get; set; }
        public ICollection<Product> ProductsBought { get; set; }
    }
}