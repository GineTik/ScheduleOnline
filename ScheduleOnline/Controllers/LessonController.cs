using Microsoft.AspNetCore.Mvc;

namespace OnlineSchedule.Controllers
{
    public class LessonController : Controller
    {
        [HttpPost]
        public string Add(string dayId)
        {
            return $"all good, lesson is added ::: dayId is {dayId}";
        }
    }
}
