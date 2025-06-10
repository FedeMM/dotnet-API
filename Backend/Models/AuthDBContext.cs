using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class AuthDBContext : IdentityDbContext
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var readerRoleId = "1f8b2c4e-4f3a-4c2b-9b5e-6c7d8e9f0a1b";
            var writerRoleId = "2f8b2c4e-4f3a-4c2b-9b5e-6c7d8e9f0a1b";

            var roles = new List<IdentityRole>
            {
                new IdentityRole { Id = readerRoleId, ConcurrencyStamp = readerRoleId, Name = "Reader", NormalizedName = "READER" },
                new IdentityRole { Id = writerRoleId, ConcurrencyStamp = writerRoleId, Name = "Writer", NormalizedName = "WRITER" },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
