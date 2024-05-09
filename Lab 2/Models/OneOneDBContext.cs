using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Lab_2.Models
{
    public class OneOneDBContext : DbContext
    {
        public DbSet<tblAddress> tblAddresses { get; set; }
        public DbSet<tblClient> tblClients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=DANG;Database=Lab2cs5;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblClient>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Client)
                .HasForeignKey<tblClient>(c => c.Address_Id);
            

            modelBuilder.Entity<tblAddress>()
                .HasOne(a => a.Client)
                .WithOne(c => c.Address)
                .HasForeignKey<tblAddress>(a => a.Addr_Id);
        }
    }

    public class tblAddress
    {
        [Key]
        public int Addr_Id { get; set; }
        [MaxLength(100)]
        public string Home_addr { get; set; }
        [MaxLength(100)]
        public string Office_addr { get; set; }
        public tblClient Client { get; set; }
    }

    public class tblClient
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        [MaxLength(50)]
        public string clientName { get; set; }
        public int Address_Id { get; set; }
        public string phoneNo { get; set; }
        public tblAddress Address { get; set; }
    }
}
