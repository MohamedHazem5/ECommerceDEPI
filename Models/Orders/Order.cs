
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ECommerce.Models.Users;

namespace ECommerce.Models.Orders
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount
        {
            get; set;
        }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId 
        {
            get; set;
        }

        // Navigation property to related order items
        public ICollection<OrderItem> OrderItems { get; set; }
    }

}
