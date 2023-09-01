using Microsoft.EntityFrameworkCore;
using Register.Domain;

namespace Register.Infrastructure.Context
{
    public class RegisterApiContext : DbContext
    {
        public RegisterApiContext(DbContextOptions<RegisterApiContext> options) : base(options) { }

        public DbSet<Addressing> Addressings { get; set; }
        public DbSet<InventoryMovement> InventoryMovements { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemsAddressing> ItemsAddressings { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Warehouse>()
                        .HasMany(s => s.Addressings)
                        .WithOne(s => s.Warehouse)
                        .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
