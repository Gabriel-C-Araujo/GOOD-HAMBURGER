using GOOD_HAMBURGER.Entity;
using Microsoft.EntityFrameworkCore;

namespace GOOD_HAMBURGER.DataBase
{
    public class AppDb : DbContext
    {
        public DbSet<Stock> Stock { get; set; } = null!;
        public DbSet<Sales> Sales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost;Database=GoodHamburger;User ID=sa;Password=123@abc;Trusted_Connection=False; TrustServerCertificate=True;");
    }
}
