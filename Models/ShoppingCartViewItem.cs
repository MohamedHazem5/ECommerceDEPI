namespace ECommerce.Models
{
    public class ShoppingCartViewItem
    {
        public List<ShoppingCartItem> Items { get; set; }
        public decimal? TotalPrice { get; set;}
        public int? TotalQuantity { get; set;}
    }
}
