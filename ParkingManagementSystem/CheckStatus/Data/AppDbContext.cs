using CheckStatus.Model;
using Microsoft.EntityFrameworkCore;

namespace CheckStatus.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CPA> MasterAvailability { get; set; }
        public DbSet<SlotModel> MasterSlot { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
