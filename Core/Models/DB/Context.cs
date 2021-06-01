using Microsoft.EntityFrameworkCore;

namespace Core.Models.DB
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        public DbSet<User> User { get; set; }
    }
}