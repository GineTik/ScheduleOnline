using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleOnline.BusinessLogic.Services;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.Interfaces;
using ScheduleOnline.Presentation.ViewModels.ScheduleViewModels;

namespace ScheduleOnline.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _rep;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public ScheduleController(IScheduleRepository rep, IMapper mapper, UserService userService)
        {
            _rep = rep;
            _mapper = mapper;
            _userService = userService;
        }

        public IActionResult Index(Guid id)
        {
            Schedule? schedule = _rep.GetItem(id);
            
            if (schedule == null)
                return NotFound(); 

            return View(schedule);
        }

        public IActionResult All()
        {
            var user = _userService.GetLoginedUser();
            var schedules = _rep.GetSchedulesOfUser(user.Id);
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

            _rep.AddItem(schedule);
            return RedirectToAction("Index", new { id = schedule.Id });
        }
    }
}