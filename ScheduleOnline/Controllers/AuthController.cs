using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScheduleOnline.BusinessLogic.Authorization;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Presentation.ViewModels.Authorization;

namespace ScheduleOnline.Controllers
{
    public class AuthController : Controller 
    {
        private readonly Authorizator _authorizator;
        private readonly IMapper _mapper;

        public AuthController(Authorizator authorizator, IMapper mapper)
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

            var result = _authorizator.TryLogin(model.Email, model.Password, model.RememberMe);
            
            if (result.Succeeded == true)
                return RedirectToAction("All", "Schedule");

            ModelState.AddModelError(String.Empty, "Невірна почта або пароль");
            return View(model);
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
            var result = _authorizator.TryRegistration(user, model.Password, model.RememberMe);

            if (result.Succeeded == true)
                return RedirectToAction("All", "Schedule");

            SetErrors(result.Errors);

            return View(model);
        }

        public IActionResult Logout()
        {
            _authorizator.Logout();
            return RedirectToAction("Login");
        }

        public void SetErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
                ModelState.AddModelError(String.Empty, error.Description);
        }
    }
}