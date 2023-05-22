using Microsoft.AspNetCore.Mvc;

namespace JournalApp.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        public IActionResult LessonsView()
        {
            return View();
        }

        public IActionResult SubjectsView()
        {
            return View();
        }

        public IActionResult StudentsView()
        {
            return View();
        }
    }
}
