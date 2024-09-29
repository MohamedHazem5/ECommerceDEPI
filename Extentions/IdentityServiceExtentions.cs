using ECommerce.Models;
using ECommerce.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace ECommerce.Extentions
{
    public static class IdentityServiceExtentions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityCore<User>(option =>
            {
                option.Password.RequireNonAlphanumeric = false;
                option.SignIn.RequireConfirmedEmail = false;
                option.SignIn.RequireConfirmedPhoneNumber = false;
            })
             .AddRoles<Role>()
             .AddRoleManager<RoleManager<Role>>()
             .AddSignInManager<SignInManager<User>>()
             .AddRoleValidator<RoleValidator<Role>>()
             .AddEntityFrameworkStores<storeContext>()
             .AddDefaultTokenProviders();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;

            })
            .AddCookie("Identity.Application")
            .AddCookie("Identity.External")
            .AddCookie("Identity.TwoFactorRememberMe")
            .AddCookie("Identity.TwoFactorUserId");
            return services;
        }
    }
}
