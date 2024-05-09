using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Lab1.Models
{
    public class CompanyContext : DbContext
    {
        public DbSet<Information> Information { get; set; }
        public DbSet<ListStudent> ListStudent { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=DANG;Database=CompanyDB;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    } 
}
