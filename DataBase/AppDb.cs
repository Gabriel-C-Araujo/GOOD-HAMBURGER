using GOOD_HAMBURGER.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GOOD_HAMBURGER.DataBase
{
    public class AppDb : DbContext
    {
        public DbSet<Stock> Stock { get; set; } = null!;
        public DbSet<Sales> Sales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost;Database=GoodHamburger;User ID=sa;Password=123@abc;Trusted_Connection=False; TrustServerCertificate=True;");
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasKey(modelBuilder => modelBuilder.PK_Stock);
            modelBuilder.Entity<Sales>().HasKey(modelBuilder => modelBuilder.PK_Sales);
                        
            base.OnModelCreating(modelBuilder);
        }
    }
}
