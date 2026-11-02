
using Microsoft.AspNetCore.Mvc;
using ASP.NETCoreMVC.Models;

namespace ASP.NETCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private static List<Student> students = new()
        {
            new Student
            {
                Id = 1,
                Name = "Hema",
                Email = "hema@gmail.com",
                Age = 22,
                Department = "IT"
            }
        };

        public IActionResult Index()
        {
            ViewData["Title"] = "MVC Practice";
            ViewBag.Message = "Welcome to ASP.NET Core MVC";
            return View(students);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Count + 1;
                students.Add(student);

                TempData["Message"] = "Student registered successfully!";
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult About()
        {
            ViewData["About"] = "ASP.NET Core MVC Learning Project";
            return View();
        }
    }
}
