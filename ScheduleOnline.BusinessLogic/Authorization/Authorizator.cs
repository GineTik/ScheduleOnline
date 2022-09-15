using ScheduleOnline.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ScheduleOnline.BusinessLogic.Services;

namespace ScheduleOnline.BusinessLogic.Authorization
{
    public class Authorizator
    {
        private readonly UserService _userService;

        public Authorizator(UserService userService)
        {
            _userService = userService;
        }

        public SignInResult TryLogin(string email, string password, bool rememberMe)
        {
            return _userService.LoginWithPassword(email, password, rememberMe);
        }
        
        public IdentityResult TryRegistration(User user, string password, bool rememberMe)
        {
            var result = _userService.CreateUser(user, password, UserService.Roles.User);

            if (result.Succeeded)
                _userService.Login(user, rememberMe);

            return result;
        }

        public void Logout()
        {
            _userService.Logout();
        }

        public bool IsLogined(ClaimsPrincipal user)
        {
            return _userService.IsLogined(user);
        }
    }
}
