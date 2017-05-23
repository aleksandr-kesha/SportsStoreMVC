using System.Data.Entity;

namespace SportsStore.Domain.Models
{
    public class DataContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }

        public DataContext() : base("DataContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(16, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
