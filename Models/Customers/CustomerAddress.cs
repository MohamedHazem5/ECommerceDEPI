using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.Customers
{
    public class CustomerAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string StreetAddress1 { get; set; }

        [StringLength(150)]
        public string StreetAddress2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }

}
