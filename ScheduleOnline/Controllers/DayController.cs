using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleOnline.BusinessLogic.Factories;
using ScheduleOnline.Data.Repositories.IdentityImplements;
using ScheduleOnline.Data.Repositories.Interfaces;
using Responses = ScheduleOnline.Presentation.Responses;

namespace ScheduleOnline.Controllers
{
    [Authorize]
    public class DayController : Controller
    {
        private readonly IDayRepository _dayRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly UserRepository _userRepository;
        private readonly DayFactory _dayFactory;

        public DayController(IDayRepository dayRepository, DayFactory dayFactory, IScheduleRepository scheduleRepository, UserRepository userRepository)
        {
            _dayRepository = dayRepository;
            _dayFactory = dayFactory;
            _scheduleRepository = scheduleRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public JsonResult Create(Guid scheduleId)
        {
            var authorId = _scheduleRepository.GetItem(scheduleId).UserId;
            var loginedUserId = _userRepository.GetLoginedUser().Id;

            if (loginedUserId != authorId)
                return Json(Responses.Response.AuthorizeError);

            var day = _dayFactory.Create(scheduleId);
            _dayRepository.AddItem(day);
            return Json(Responses.ContentResponse.SuccessWithContent(day));
        }

        [HttpPost]
        public JsonResult Remove(Guid dayId)
        {
            // доделать проверку на владельца этого дня

            var day = _dayRepository.GetItem(dayId);

            if (day == null)
                return Json(Responses.Response.Error);
            
            _dayRepository.DeleteItem(day);
            return Json(Responses.Response.Success);
        }

        [HttpPost]
        public JsonResult ChangeTitle(Guid id, string title)
        {
            // доделать проверку на владельца этого дня

            var day = _dayRepository.GetItem(id);

            if (day == null)
                return Json(Responses.Response.Error);

            day.Title = title;
            _dayRepository.UpdateItem(day);

            return Json(Responses.Response.Success);
        }
    }
}
