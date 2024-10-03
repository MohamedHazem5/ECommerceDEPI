using ECommerce.Models.Products;
using ECommerce.Models.Customers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.Carts
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("customerid")]

        public Customer customer { get; set; }
        public int customerid { get; set; }
    }
}
