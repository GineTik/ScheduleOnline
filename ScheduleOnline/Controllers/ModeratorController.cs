using Microsoft.AspNetCore.Mvc;

namespace ScheduleOnline.Controllers
{
    public class ModeratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
