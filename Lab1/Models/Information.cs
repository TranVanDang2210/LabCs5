using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class Information
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Linsence { get; set; }

        public DateTime Establshied { get; set; }

        public  decimal  Revenue { get; set; }

    }
    public class ListStudent
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public ICollection<Information> Namess { get; set; }
    }

}
