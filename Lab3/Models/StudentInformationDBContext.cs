using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class StudentInformationDBContext : DbContext
    {
        public DbSet<StudentInfo> StudentInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=DANG;Database=Lab3cs5;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentInfo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfBirth)
                    .IsRequired();

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .HasMaxLength(100);

                entity.Property(e => e.WebsiteUrl)
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasMaxLength(100);

                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(100);
                entity.Property(e => e.Gender)
                    .HasConversion<string>();
            });
        }
    }
      

        public class StudentInfo
        {
        public int Id { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên không được vượt quá 100 kí tự")]
        public string Name { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        public DateTime BackTime { get; set; }

        [StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 10 chữ số")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có 10 chữ số")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Url(ErrorMessage = "URL trang web không hợp lệ")]
        public string WebsiteUrl { get; set; }

        [StringLength(100, ErrorMessage = "Mật khẩu phải có ít nhất {2} kí tự và không quá {1} kí tự", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }


    


}
    

