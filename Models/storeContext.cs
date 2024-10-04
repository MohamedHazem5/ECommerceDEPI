using System.Collections.Generic;
using ECommerce.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class storeContext : IdentityDbContext<User, Role, int,
    IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
    
        public storeContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<User>().ToTable("Users");
            builder.Entity<UserRole>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");

            builder.Entity<User>()
                   .HasMany(ur => ur.UserRoles)
                   .WithOne(u => u.User)
                   .HasForeignKey(ur => ur.UserId)
                   .IsRequired();

            builder.Entity<Role>()
                .HasMany(ur => ur.UsersRole)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        }

        public DbSet<Carts.Cart> Carts { get; set; }
        public DbSet<Carts.CartItem> CartItems { get; set; }

        public DbSet<Orders.Order> Orders { get; set; }
        public DbSet<Orders.OrderItem> OrderItems { get; set; }

        public DbSet<Payments.Payment> Payments { get; set; }
        public DbSet<Products.Category> Categories { get; set; }

        public DbSet<Products.Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Products.ProductReview> ProductReviews { get; set; }
        public DbSet<Shippings.Shipping> Shippings { get; set; }
        public DbSet<Vendors.Vendor> Vendor { get; set; }


    }
}
