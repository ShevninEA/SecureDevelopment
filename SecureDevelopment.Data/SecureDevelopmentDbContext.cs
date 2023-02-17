using Microsoft.EntityFrameworkCore;

namespace SecureDevelopment.Data
{
    public class SecureDevelopmentDbContext : DbContext
    {
        public DbSet<Card> Card { get; set; } 
        public DbSet<Client> Client { get; set; } 

        public SecureDevelopmentDbContext(DbContextOptions options) : base(options) { }
    }
}