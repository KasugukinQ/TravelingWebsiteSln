using Microsoft.EntityFrameworkCore;

namespace TravelingWebsite.Models
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options) { }

        public DbSet<Package> Packages => Set<Package>();
    }
}
