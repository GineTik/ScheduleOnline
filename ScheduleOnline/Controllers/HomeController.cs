using Microsoft.AspNetCore.Mvc;

namespace OnlineSchedule.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
