
using ECommerce.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models
{
    [NotMapped]
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public int Quantitiy {  get; set; }
    }
}
