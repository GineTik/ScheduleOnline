using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.IdentityImplements;
using ScheduleOnline.Data.Repositories.Interfaces;
using ScheduleOnline.Presentation.ViewModels.ScheduleViewModels;

namespace ScheduleOnline.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IDayRepository _dayRepository;
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;

        public ScheduleController(IScheduleRepository rep, IMapper mapper, UserRepository userRepository, IDayRepository dayRepository)
        {
            _scheduleRepository = rep;
            _mapper = mapper;
            _userRepository = userRepository;
            _dayRepository = dayRepository;
        }

        public IActionResult Index(Guid id)
        {
            Schedule? schedule = _scheduleRepository.GetItem(id);

            if (schedule == null)
                return NotFound(); 

            schedule.Days = _dayRepository.GetDaysOfSchedule(id).ToList();
            return View(schedule);
        }

        public IActionResult All()
        {
            var user = _userRepository.GetLoginedUser();
            var schedules = _scheduleRepository.GetSchedulesOfUser(user.Id);
            var models = _mapper.Map<List<ShortDataScheduleViewModel>>(schedules);

            return View(models);
        }

        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddScheduleViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var schedule = _mapper.Map<Schedule>(model);

            _scheduleRepository.AddItem(schedule);
            return RedirectToAction("Index", new { id = schedule.Id });
        }

        public void ChangeTitle(Guid id, string title)
        {
            var schedule = _scheduleRepository.GetItem(id);

            if (schedule == null)
                throw new ArgumentNullException(nameof(id));

            schedule.Title = title;
            _scheduleRepository.UpdateItem(schedule);
        }
    }
}