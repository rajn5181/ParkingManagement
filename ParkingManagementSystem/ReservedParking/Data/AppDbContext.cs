using Microsoft.EntityFrameworkCore;
using ReservedParking.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ReservedParking.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RGPModel> MasterReserved { get; set; }
        public DbSet<TypesofVechicleModel> VCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
