namespace Lab32.Models
{
    public class ProductViewModel
    { 
        public int Id { get; set; }
        public string Name { get; internal set; }
    }

    public interface IProductService
    {
        List<ProductViewModel> GetAll();
    }

    public class ProductService : IProductService
    {
        public List<ProductViewModel> GetAll()
        {
            return new List<ProductViewModel>
            {
                new ProductViewModel {Id = 1 , Name = "Pen Drive"},
               
                new ProductViewModel {Id = 2 , Name = "Memory Card"},

                new ProductViewModel {Id = 3 , Name = "Mobile Phone"},

                new ProductViewModel {Id = 4 , Name = "Tablet"},

                new ProductViewModel {Id = 5 , Name = "Desktop PC"},

            };
        }
    }
}
