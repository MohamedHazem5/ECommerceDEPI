
using ECommerce.Models.Orders;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.Users
{
    public class User : IdentityUser<int>
    {

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        public DateTime RegisteredDate { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }


    }
}
