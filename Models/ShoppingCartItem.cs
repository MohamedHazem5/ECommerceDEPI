using ECommerce.Models.Customers;
using ECommerce.Models.Products;
namespace ECommerce.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public int Quantitiy {  get; set; }
    }
}
