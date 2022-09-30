using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleOnline.BusinessLogic.Factories;
using ScheduleOnline.Data.Repositories.IdentityImplements;
using ScheduleOnline.Data.Repositories.Interfaces;

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
                throw new InvalidOperationException("logined user is not author this schedule");

            var day = _dayFactory.Create(scheduleId);
            _dayRepository.AddItem(day);
            return Json(day);
        }
    }
}
