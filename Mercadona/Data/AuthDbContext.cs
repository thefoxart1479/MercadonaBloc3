using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mercadona_V3.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "054e0b7d-8297-432d-b73f-afc0138c44f4";
            var adminRole = new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId
            };

            builder.Entity<IdentityRole>().HasData(adminRole);

            var adminUserId = "25033cc8-f09e-4d5f-a0c7-c50a724fa5c1";
            var adminUser = new IdentityUser
            {
                UserName = "adminmercadona",
                Email = "admin@mercadona.com",
                NormalizedEmail = "admin@mercadona.com".ToUpper(),
                NormalizedUserName = "adminmercadona".ToUpper(),
                Id = adminUserId,
            };
            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, "mercadonaBloc3");

            builder.Entity<IdentityUser>().HasData(adminUser);

            var adminRoles = new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId,
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
            
        }
    }
}
