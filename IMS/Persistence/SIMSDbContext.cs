// Persistence/SIMSDbContext.cs
using Domain.Common;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class SIMSDbContext : DbContext
    {
        public SIMSDbContext(DbContextOptions<SIMSDbContext> options) : base(options)
        {
        }

        // Added the Users DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Godown> Godowns { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InwardTransaction> InwardTransactions { get; set; }
        public DbSet<OutwardTransaction> OutwardTransactions { get; set; }
        public DbSet<ReturnTransaction> ReturnTransactions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SIMSDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                // This is where you would handle common properties like CreatedDate
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}