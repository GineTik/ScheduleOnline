using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineSchedule.BusinessLogic.Services;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Data.Repositories.Interfaces;
using OnlineSchedule.Presentation.ViewModels;

namespace OnlineSchedule.Controllers 
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _rep;
        private readonly Mapper _mapper;
        private readonly UserService _userService;

        public ScheduleController(IScheduleRepository rep, Mapper mapper, UserService userService)
        {
            _rep = rep;
            _mapper = mapper;
            _userService = userService;
        }

        public IActionResult Index(Guid id)
        {
            if (id == Guid.Empty)
                return View();

            Schedule schedule = _rep.Get(id);
            if (schedule == null)
                return NotFound(); 
            return View(schedule);
        }

        public IActionResult All()
        {
            var user = _userService.GetUser(HttpContext.User);
            var schedules = _rep.GetByUserId(user.Id);
            var models = _mapper.Map<List<ScheduleListItem>>(schedules);

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

            _rep.Add(schedule);
            return RedirectToAction("Index", new { id = schedule.Id });
        }
    }
}