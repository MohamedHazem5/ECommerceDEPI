using System.ComponentModel;

namespace ECommerce.Models.Dtos
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
