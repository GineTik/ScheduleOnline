using Microsoft.AspNetCore.Identity;
using ScheduleOnline.Data.Entities;
using System.Security.Claims;

namespace ScheduleOnline.BusinessLogic.Services
{
    public class UserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IdentityResult CreateUser(User user, string password)
        {
            return _userManager.CreateAsync(user, password).GetAwaiter().GetResult();
        }

        public void Login(User user, bool rememberMe)
        {
            _signInManager.SignInAsync(user, isPersistent: rememberMe);
        }

        public SignInResult LoginWithPassword(User user, bool rememberMe, string password)
        {
            return _signInManager.PasswordSignInAsync(user, password, rememberMe, false).GetAwaiter().GetResult();
        }

        public void Logout()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
        }

        public bool IsLogined(ClaimsPrincipal user)
        {
            return _signInManager.IsSignedIn(user);
        }

        public void AttachRole(User user, string roleName)
        {
            var role = new Role { Name = roleName };

            if (_roleManager.Roles.Contains(role) == false)
                _roleManager.CreateAsync(role);

            _userManager.AddToRoleAsync(user, roleName);
        }

        public List<User> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
        }
    }
}
