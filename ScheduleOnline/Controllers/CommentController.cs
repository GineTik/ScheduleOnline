using Microsoft.AspNetCore.Mvc;
using ScheduleOnline.Data.Repositories.IdentityImplements;
using ScheduleOnline.Data.Repositories.Interfaces;

namespace ScheduleOnline.Controllers
{
    public class CommentController : Controller
    {
        public readonly IScheduleRepository _scheduleRepository;
        public readonly UserRepository _userRepository;

        public CommentController(IScheduleRepository scheduleRepository, UserRepository userRepository)
        {
            _scheduleRepository = scheduleRepository;
            _userRepository = userRepository;
        }

        public IActionResult SwitchCommentsState(Guid scheduleId)
        {
            var authorId = _scheduleRepository.GetItem(scheduleId)?.UserId;
            var loginedUserId = _userRepository.GetLoginedUser()?.Id;

            if (loginedUserId != authorId)
                throw new ArgumentException("не доступна функція для цього корисувача");

            _scheduleRepository.SwitchComments(scheduleId);
            return RedirectToAction("Index", "Schedule", new { id = scheduleId });
        }

    }
}
