using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Lab2._3.Models
{
    public class MoreMoreDBContext : DbContext
    {   
        DbSet<PersonCompanies> PersonCompaniess { get; set; }
        DbSet<People> peoples { get; set; }
        DbSet<Companie> companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=DANG;Database=Lab2cs5;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonCompanies>()
                .ToTable("PersonCompanies", schema:"Lab23" );

            modelBuilder.Entity<People>()
                .ToTable("People", schema: "Lab23");

            modelBuilder.Entity<Companie>()
                .ToTable("Companies", schema: "Lab23");

            modelBuilder.Entity<PersonCompanies>()
            .HasOne(pc => pc.People)
            .WithMany(p => p.PersonCompaniess)
            .HasForeignKey(pc => pc.PersonId);

            modelBuilder.Entity<PersonCompanies>()
                .HasOne(pc => pc.Companie)
                .WithMany(c => c.PersonCompaniess)
                .HasForeignKey(pc => pc.CompanyId);

        }
    }

    public class People
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public ICollection<PersonCompanies> PersonCompaniess { get; set; }
    }

    public class Companie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<PersonCompanies> PersonCompaniess { get; set; }
    }

    public class PersonCompanies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FromYear { get; set; }
        [Required]
        public int ToYear { get; set; }
        [Required]
        public bool Current { get; set; }
        [StringLength(100)]
        public string Position { get; set; }

        public int CompanyId { get; set; }
        public Companie Companie { get; set; }

        public int PersonId { get; set; }
        public People People { get; set; }
    }

}
