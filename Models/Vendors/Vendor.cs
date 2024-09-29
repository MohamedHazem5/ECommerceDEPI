using ECommerce.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.Vendors
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]

        public string Description
        {
            get;
            set;
        }

        // Navigation property to related products
        public ICollection<Product> Products { get; set; }
    }
}
