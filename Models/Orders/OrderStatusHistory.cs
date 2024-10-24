using ECommerce.Models._Enums;
using ECommerce.Models.Users;

namespace ECommerce.Models.Orders
{
    /*
        Id: A unique identifier for each status change.
        OrderId: The ID of the order that was affected by the change.
        OldStatus: The previous status of the order.
        NewStatus: The new status of the order.
        ChangeDate: The date and time when the change occurred.
        ChangedBy: The user who made the change (optional).
    */
    public class OrderStatusHistory
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderStatus OldStatus { get; set; }
        public OrderStatus NewStatus { get; set; }
        public DateTime ChangeDate { get; set; }
        public int UserId { get; set; }

        // Navigation property to the Order entity (optional)
        public Order Order { get; set; }

        // Navigation property to the User entity (optional)
        public User User { get; set; }
    }
}
