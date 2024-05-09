using System.ComponentModel.DataAnnotations;

namespace FinalLab1.Models
{
    public class Products
    {
        [Key]   
        public int ID { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public bool Status { get; set; }
    }
}
