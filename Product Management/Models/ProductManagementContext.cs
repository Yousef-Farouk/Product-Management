using Microsoft.EntityFrameworkCore;

namespace Product_Management.Models
{
    public class ProductManagementContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ClientProducts> ClientProducts { get; set; }


        public ProductManagementContext(DbContextOptions<ProductManagementContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure the Code property in Client is unique
            modelBuilder.Entity<Client>()
                .HasIndex(c => c.Code)
                .IsUnique();

            // Adding Composite Key
            modelBuilder.Entity<ClientProducts>()
                .HasKey(cp => new { cp.ClientId, cp.ProductId });


            // Configure ClientClass and ClientState to be stored as strings
            modelBuilder.Entity<Client>()
                .Property(c => c.Class)
                .HasConversion<string>();

            modelBuilder.Entity<Client>()
                .Property(c => c.State)
                .HasConversion<string>();

        }
    }
}
