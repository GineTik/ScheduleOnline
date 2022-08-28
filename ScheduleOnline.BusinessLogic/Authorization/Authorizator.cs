using ScheduleOnline.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ScheduleOnline.BusinessLogic.Authorization
{
    public class Authorizator
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public Authorizator(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public SignInResult TryLogin(User user, string password, bool rememberMe)
        {
            return _signInManager.PasswordSignInAsync(user, password, rememberMe, false).GetAwaiter().GetResult();
        }
        
        public IdentityResult TryRegistration(User user, string password, bool rememberMe)
        {
            var result = _userManager.CreateAsync(user, password).GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                AttachRole(user, "User");
                _signInManager.SignInAsync(user, isPersistent: rememberMe);
            }

            return result;
        }

        public void Logout()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
        }

        public bool IsLogined(ClaimsPrincipal user)
        {
            return string.IsNullOrEmpty(_userManager.GetUserId(user));
        }

        private void AttachRole(User user, string roleName)
        {
            var role = new Role { Name = roleName };

            if (_roleManager.Roles.Contains(role) == false)
                _roleManager.CreateAsync(role);

            _userManager.AddToRoleAsync(user, roleName);
        }
    }
}
