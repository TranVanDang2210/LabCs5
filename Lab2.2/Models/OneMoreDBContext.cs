using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading.Tasks.Sources;

namespace Lab2._2.Models
{
    public class OneMoreDBContext : DbContext
    {
        DbSet<Nhanvien> nhanviens { get; set; }
        DbSet<Thannhan> thannhans { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=DANG;Database=Lab2cs5;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nhanvien>()
        .ToTable("Nhanvien", schema: "Lab22"); 

            modelBuilder.Entity<Thannhan>()
                .ToTable("Thannhan", schema: "Lab22"); 
            modelBuilder.Entity<Thannhan>()
                .HasKey(tn => new { tn.ma_nv, tn.tenthannhan });

            modelBuilder.Entity<Thannhan>()
       .HasOne(tn => tn.Nhanvien)
       .WithMany(nv => nv.thannhans)
       .HasForeignKey(tn => tn.ma_nv)
       .IsRequired();
        }
    }
    public class Nhanvien
    {
        [Key]
        [Required]
        public int manv { get; set; }
        public string honv { get; set; }

        [Required]
        public string tennv { get; set; }
        [Required]
        public string tenlot { get; set; }
        [Required]
        public DateTime ngaysinh { get; set; }
        [Required]
        public string dchi { get; set; }
        [Required]
        public string phai { get; set; }
        [Required]
        public float luong { get; set; }
        [Required]
        public char ma_nql { get; set; }
        public int phg { get; set; }
        public ICollection<Thannhan> thannhans { get; set; }
    }

    public class Thannhan
    {
           
        public int ma_nv { get; set; }
        public string tenthannhan { get; set; }
        [Required]
        public char phai { get; set; }
        [Required]
        public DateTime nsinh { get; set; }
        [Required]
        public string qhe { get; set; }
        public Nhanvien Nhanvien { get; set; }
    }
}
