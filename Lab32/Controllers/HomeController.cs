using Lab32.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab32.Controllers
{
    public class HomeController : Controller
    {
      
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }       
        public IActionResult Index()
        {
            _productService = new ProductService();
            return View(_productService.GetAll());
        }


    }
}