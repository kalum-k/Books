using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UserModel> User { get; set; }
    }
}
