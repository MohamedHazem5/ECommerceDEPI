using ECommerce.Models.Customers;
using ECommerce.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.Carts
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId
        {
            get; set;
        }

        // Navigation property to related cart items
        public ICollection<CartItem> CartItems { get; set; }
    }

    
}
