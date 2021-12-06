using Boards.AuthService.Database.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Boards.AuthService.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserModel>(user =>
            {
                user.Property(u => u.Email).IsRequired().HasMaxLength(50);
                user.Property(u => u.Password).IsRequired().HasMaxLength(200);
            });

            builder.Entity<UserModel>().HasIndex(u => u.Email).IsUnique();
        }
    }
}