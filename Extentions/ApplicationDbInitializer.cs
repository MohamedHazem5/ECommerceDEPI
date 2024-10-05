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

            // Seed Customer1 User
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

            // Seed Customer2 User
            var customer2Email = "customer2@gmail.com";
            var customer2User = await userManager.FindByEmailAsync(customer2Email);
            if (customer2User == null)
            {
                var customer2 = new User
                {
                    UserName = customer2Email.Substring(0, customer2Email.IndexOf("@")),
                    Email = customer2Email,
                    FirstName = "customer2",
                    LastName = "customer2",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(customer2, "Pa$$w0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(customer2, "Customer");
                }
            }

            // Seed Vendor1 User
            var vendor1Email = "vendor1@gmail.com";
            var vendor1User = await userManager.FindByEmailAsync(vendor1Email);
            if (vendor1User == null)
            {
                var vendor1 = new User
                {
                    UserName = vendor1Email.Substring(0, vendor1Email.IndexOf("@")),
                    Email = vendor1Email,
                    FirstName = "vendor1",
                    LastName = "vendor1",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(vendor1, "Pa$$w0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(vendor1, "Vendor");
                }
            }
            
            // Seed Vendor2 User
            var vendor2Email = "vendor2@gmail.com";
            var vendor2User = await userManager.FindByEmailAsync(vendor2Email);
            if (vendor2User == null)
            {
                var vendor2 = new User
                {
                    UserName = vendor2Email.Substring(0, vendor2Email.IndexOf("@")),
                    Email = vendor2Email,
                    FirstName = "vendor2",
                    LastName = "vendor2",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(vendor2, "Pa$$w0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(vendor2, "Vendor");
                }
            }
        }
    }
}
