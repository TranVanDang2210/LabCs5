using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string Index()
        {
            using (var context = new CompanyContext())
            {
                var info = new Information()
                {
                    Name = "Tran Van Dang ",
                    Linsence = "Dangcoppyright",
                    Revenue = 2004,
                    Establshied = Convert.ToDateTime("2024/10/10")
                };
                context.Information.Add(info);
                context.SaveChanges();
            }
            return "Record Inserted";
        }

  
    }
}