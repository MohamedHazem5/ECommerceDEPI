using ECommerce.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Extentions
{
    public static class ApplicationDbInitializer
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            // Seed Roles
            string[] roleNames = { "Admin", "Customer","Vendor"};
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new Role { Name = roleName });
                }
            }

            // Seed Admin User
            var adminEmail = "admin@gmail.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var admin = new User
                {
                    UserName = adminEmail.Substring(0,adminEmail.IndexOf("@")),
                    Email = adminEmail,
                    FirstName = "admin",
                    LastName = "admin",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, "Pa$$w0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
            // Seed Admin User
            var customer1Email = "customer1@gmail.com";
            var customer1User = await userManager.FindByEmailAsync(customer1Email);
            if (customer1User == null)
            {
                var customer1 = new User
                {
                    UserName = customer1Email.Substring(0, customer1Email.IndexOf("@")),
                    Email = customer1Email,
                    FirstName = "customer1",
                    LastName = "customer1",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(customer1, "Pa$$w0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(customer1, "Customer");
                }
            }
        }
    }
}
