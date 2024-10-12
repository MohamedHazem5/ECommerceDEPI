
using ECommerce.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ECommerce.Models.Users;

namespace ECommerce.Models.Carts
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId
        {
            get; set;
        }

        // Navigation property to related cart items
        public ICollection<CartItem> CartItems { get; set; }
    }

    
}
