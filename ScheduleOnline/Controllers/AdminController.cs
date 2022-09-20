using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.IdentityImplements;
using ScheduleOnline.Presentation.ViewModels.UserViewModels;
using Roles = ScheduleOnline.Data.Repositories.IdentityImplements.RoleRepository.Roles;

namespace ScheduleOnline.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class AdminController : Controller 
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public AdminController(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var loginedUser = _userRepository.GetLoginedUser();
            var users = _userRepository.GetAllUsers();
            users.Remove(loginedUser);
            var models = _mapper.Map<List<ShortDataUserViewModel>>(users);
            return View(models);
        }

        public IActionResult Find(string email)
        {
            var loginedUser = _userRepository.GetLoginedUser();
            var users = _userRepository.GetUsersByPartEmail(email);
            users.Remove(loginedUser);

            if (users.Count == 0)
                return View("Index", null);

            var models = _mapper.Map<List<ShortDataUserViewModel>>(users);
            return View("Index", models);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        private void SetErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var item in errors)
                ModelState.AddModelError(string.Empty, item.Description);
        }
    }
}