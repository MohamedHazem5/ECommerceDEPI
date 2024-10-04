using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ECommerce.Models.Users;

namespace ECommerce.Models.Products
{
    public class ProductReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(255)]
        public string Comment { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("UserId")]
        public User Customer { get; set; }
        public int UserId { get; set; }
    }

}
