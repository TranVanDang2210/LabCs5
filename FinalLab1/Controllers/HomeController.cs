using FinalLab1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
namespace FinalLab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private CompanyContext db = new CompanyContext();

        [Route("")]
        
        public IActionResult Index()
        {
            ViewBag.product = db.Products.ToList();
            return View();
        }

        [Route("add")]
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add(Products products)
        {
            db.Products.Add(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("edit")]
        [HttpGet]
        public IActionResult Edit()
        {
            
            return View("Edit");
        }

        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products products)
        {   db.Entry(products).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("delete")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View ("Delete");
        }

        [Route("delete")]
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            db.Products.Remove(db.Products.Find(ID));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}