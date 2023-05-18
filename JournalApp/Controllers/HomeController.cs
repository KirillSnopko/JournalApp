using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
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
