using ScheduleOnline.Data.Entities;
using Microsoft.AspNetCore.Identity;
using ScheduleOnline.Data.Repositories.IdentityImplements;

namespace ScheduleOnline.BusinessLogic.Authorization
{
    public class Authorizator
    {
        private readonly UserRepository _userService;
        private readonly SignInManager<User> _signInManager;

        public bool Logined => _signInManager.IsSignedIn(_userService.HttpContext.User);
        public User LoginedUser => _userService.GetLoginedUser();

        public Authorizator(UserRepository userService, SignInManager<User> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        public SignInResult TryLogin(string email, string password, bool rememberMe)
        {
            return _signInManager.PasswordSignInAsync(email, password, rememberMe, false).GetAwaiter().GetResult();
        }
        
        public IdentityResult TryRegistration(User user, string password, bool rememberMe)
        {
            var result = _userService.CreateUser(user, password, RoleRepository.Roles.User);

            if (result.Succeeded) 
                _signInManager.SignInAsync(user, isPersistent: rememberMe).GetAwaiter().GetResult();

            return result;
        }

        public void Logout()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
        }
    }
}
