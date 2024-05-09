using Microsoft.EntityFrameworkCore;

namespace FinalLab1.Models
{
    public class CompanyContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=DANG;Database=Company;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
