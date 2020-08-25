using AsyncEnumerableInterface.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsyncEnumerableInterface.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) 
            : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
    }
}
