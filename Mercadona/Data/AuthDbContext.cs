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

            var adminRoleId = "";
            var adminRole = new IdentityRole
            {
                Name = "",
                NormalizedName = "",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId
            };

            builder.Entity<IdentityRole>().HasData(adminRole);

            var adminUserId = "";
            var adminUser = new IdentityUser
            {
                UserName = "",
                Email = "",
                NormalizedEmail = "".ToUpper(),
                NormalizedUserName = "".ToUpper(),
                Id = adminUserId,
            };
            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, "");

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
