namespace ProductShop.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CategoryProduct
    {
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
