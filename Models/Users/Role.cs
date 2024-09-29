using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models.Users
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UsersRole { get; set; }

    }
}
