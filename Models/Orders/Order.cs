
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ECommerce.Models.Users;
using ECommerce.Models._Enums;

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
        private OrderStatus _status;
        public OrderStatus? Status 
        {   
            get { return _status; }
            set 
            {
                if (value == null)
                {
                    _status = OrderStatus.Pending;
                }
                else
                {
                    _status = value.Value;
                }
            } 
        }
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        // Navigation property to related order items
        public ICollection<OrderItem> OrderItems { get; set; }
    }

}
