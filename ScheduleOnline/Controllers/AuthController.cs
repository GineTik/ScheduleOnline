using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScheduleOnline.BusinessLogic.Authorization;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Presentation.ViewModels.Authorization;

namespace OnlineSchedule.Controllers
{
    public class AuthController : Controller 
    {
        private readonly Authorizator _authorizator;
        private readonly Mapper _mapper;

        public AuthController(Authorizator authorizator, Mapper mapper)
        {
            _authorizator = authorizator;
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            if (_authorizator.IsLogined(HttpContext.User) == true)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var user = _mapper.Map<User>(model);

            var loginResult = _authorizator.TryLogin(user, model.Password, model.RememberMe);
            if (loginResult.Succeeded == false)
            {
                ModelState.AddModelError(String.Empty, "Невірна почта або пароль");
                return View(model);
            }

            return RedirectToAction("All", "Schedule");
        }

        public IActionResult Registration()
        {
            if (_authorizator.IsLogined(HttpContext.User) == true)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var user = _mapper.Map<User>(model);
            var registrationResult = _authorizator.TryRegistration(user, model.Password, model.RememberMe);

            if (registrationResult.Succeeded == false)
            {
                foreach (var error in registrationResult.Errors)
                    ModelState.AddModelError(String.Empty, error.Description);

                return View(model);
            }

            return RedirectToAction("All", "Schedule");
        }

        public IActionResult Logout()
        {
            _authorizator.Logout();
            return RedirectToAction("Login");
        }
    }
}