using Microsoft.AspNetCore.Mvc;

namespace OnlineSchedule.Controllers
{
    public class DayController : Controller
    {
        [HttpPost]
        public string Add(string scheduleId)
        {
            return $"all good, schedule id is {scheduleId}";
        }
    }
}
