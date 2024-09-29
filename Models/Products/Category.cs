using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.Products
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Navigation property to related products
        public ICollection<Product> Products { get; set; }
    }

}
