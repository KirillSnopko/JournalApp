using Microsoft.AspNetCore.Mvc;

namespace JournalApp.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
