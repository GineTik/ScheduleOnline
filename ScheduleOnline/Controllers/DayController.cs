using Microsoft.AspNetCore.Mvc;

namespace ScheduleOnline.Controllers
{
    public class DayController : Controller
    {
        [HttpPost]
        public string Create(string scheduleId)
        {
            return $"all good, schedule id is {scheduleId}";
        }
    }
}
