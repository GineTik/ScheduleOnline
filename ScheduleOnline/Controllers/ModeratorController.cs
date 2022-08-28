using Microsoft.AspNetCore.Mvc;

namespace OnlineSchedule.Controllers
{
    public class ModeratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
