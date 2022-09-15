using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScheduleOnline.BusinessLogic.Services;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Presentation.ViewModels.UserViewModels;
using Roles = ScheduleOnline.BusinessLogic.Services.UserService.Roles;

namespace ScheduleOnline.Controllers
{
    [Authorize(Roles = nameof(Roles.User))]
    public class AdminController : Controller 
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public AdminController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            var models = _mapper.Map<List<ShortDataUserViewModel>>(users);
            return View(models);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var user = _mapper.Map<User>(model);

            var role = (Roles)Enum.Parse(typeof(Roles), model.Role);
            var result = _userService.CreateUser(user, model.Password, role);

            if (result.Succeeded == true)
                return RedirectToAction("Index");

            SetErrors(result.Errors);

            return View(model);
        }

        private void SetErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var item in errors)
                ModelState.AddModelError(string.Empty, item.Description);
        }
    }
}