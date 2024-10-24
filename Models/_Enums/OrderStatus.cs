namespace ECommerce.Models._Enums
{
    public enum OrderStatus
    {
        // Pending: The order has been placed but not yet processed.
        Pending = 0,
        // Processing: The order is currently being prepared for shipment.
        Processing = 1,
        // Shipped: The order has been shipped and is on its way to the customer.
        Shipped = 2,
        // Delivered: The order has been successfully delivered to the customer.
        Delivered = 3,
        // Canceled: The order has been canceled by the customer or the seller.   
        Canceled = 4
    }
}

