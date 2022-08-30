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

        public SignInResult TryLogin(User user, string password, bool rememberMe)
        {
            return _userService.LoginWithPassword(user, rememberMe, password);
        }
        
        public IdentityResult TryRegistration(User user, string password, bool rememberMe)
        {
            var result = _userService.CreateUser(user, password);

            if (result.Succeeded)
            {
                _userService.AttachRole(user, "User");
                _userService.Login(user, rememberMe);
            }

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
