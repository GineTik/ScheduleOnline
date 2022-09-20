using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.IdentityImplements;
using ScheduleOnline.Presentation.ViewModels.UserViewModels;
using Roles = ScheduleOnline.Data.Repositories.IdentityImplements.RoleRepository.Roles;

namespace ScheduleOnline.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class UserController : Controller
    {
        private readonly UserRepository _userService;
        private readonly IMapper _mapper;

        public UserController(UserRepository userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var user = _mapper.Map<User>(model);

            var role = (Roles)Enum.Parse(typeof(Roles), model.Role);
            var result = _userService.CreateUser(user, model.Password, role);

            if (result.Succeeded == true)
                return RedirectToAction("Index");

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        [HttpPost]
        public void RemoveUser(Guid userId)
        {
            if (_userService.GetUserById(userId) != null &&
                _userService.IsRemoved(userId) == false)
                _userService.Remove(userId);
        }

        [HttpPost]
        public void RestoreUser(Guid userId)
        {
            if (_userService.IsRemoved(userId) == true)
                _userService.Restore(userId);
        }
    }
}
