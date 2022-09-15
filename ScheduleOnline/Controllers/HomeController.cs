using Microsoft.AspNetCore.Mvc;

namespace ScheduleOnline.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
