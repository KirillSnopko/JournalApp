using Microsoft.AspNetCore.Mvc;

namespace JournalApp.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        public IActionResult Lessons()
        {
            return View();
        }

        public IActionResult Subjects()
        {
            return View();
        }

        public IActionResult Students()
        {
            return View();
        }
    }
}
