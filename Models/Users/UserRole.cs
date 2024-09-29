using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models.Users
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
