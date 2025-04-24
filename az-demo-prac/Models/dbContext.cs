using Microsoft.EntityFrameworkCore;

namespace az_demo_prac.Models
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }

        public DbSet<Earn> Earns { get; set; }
    }
}
