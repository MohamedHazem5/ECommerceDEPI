using System.ComponentModel.DataAnnotations;
using ECommerce.Models.Orders;

namespace ECommerce.Models.Customers
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public  string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime RegisteredDate { get; set; }

        // Navigation property to related customer addresses
        public ICollection<CustomerAddress> CustomerAddresses { get; set; }

        // Navigation property to related customer orders
        public ICollection<Order> Orders { get; set; }
    }
}
