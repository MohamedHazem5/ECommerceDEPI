using ECommerce.Models.Companies;
using ECommerce.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ECommerce.Models.Shipping
{
    public class CompanyShipping
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public string ShippingName { get; set; }

        public string ShippingAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string Notes { get; set; }

    }
}
