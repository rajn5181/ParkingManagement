using Microsoft.EntityFrameworkCore;
using PayemetServices.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PayemetServices.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PaymentReceiptModel> PaymentReceipts { get; set; }
        public DbSet<PaymentHistoryModel> PaymentHistories { get; set; }
        public DbSet<PayementModel> Payments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentReceiptModel>()
         .HasOne(pr => pr.Payment)
         .WithMany() 
         .HasForeignKey(pr => pr.PaymentID);
        }
    }
}
