using Microsoft.AspNetCore.Mvc;

namespace ScheduleOnline.Controllers
{
    public class LessonController : Controller
    {
        [HttpPost]
        public string Create(string dayId)
        {
            return $"all good, lesson is added ::: dayId is {dayId}";
        }
    }
}
