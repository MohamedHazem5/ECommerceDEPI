using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.Shippings
{
    public class Shipping
    {
        [Key]
        public int Id { get; set; }

        // UPS, FedEx, DHL, ... etc
        public string Carrier { get; set; }

        public decimal Rate { get; set; }

        public int EstimatedDeliveryDays { get; set; }

        // Other shipping-related properties
    }
}
