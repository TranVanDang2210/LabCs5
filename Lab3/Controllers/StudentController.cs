using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class StudentController : Controller
    {
  
        private StudentInformationDBContext db = new StudentInformationDBContext();


        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Student = db.StudentInfos.ToList();
            return View();
        }
        [Route("add")]
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [Route("add")]
        [HttpPost]
        public IActionResult Create(StudentInfo student)
        {
            if (ModelState.IsValid)
            {
                
                db.StudentInfos.Add(student);
                db.SaveChanges();

                return RedirectToAction("Create");
            }

            return View(student);
        }
    }
}
