using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ScheduleOnline.Data.Entities;
using System.Security.Claims;

namespace ScheduleOnline.BusinessLogic.Services
{
    public class UserService
    {
        public enum Roles
        {
            User,
            Moderator,
            Admin
        }

        //private readonly Dictionary<Roles, string> _rolesRoute = new Dictionary<Roles, string>()
        //{
        //    { Roles.User, "User" },
        //    { Roles.Moderator, "Moderator" },
        //    { Roles.Admin, "Admin" }
        //};

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly HttpContext _httpContext;

        public UserService(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _httpContext = accessor.HttpContext;
        }

        public IdentityResult CreateUser(User user, string password, Roles role)
        {
            if (UserIsExists(user.Email) == true)
                return IdentityResult.Failed(new IdentityError(){ Description = "Такий користувач вже існує" });

            var result = _userManager.CreateAsync(user, password).GetAwaiter().GetResult();

            if (result.Succeeded == true)
                AttachRole(user, role);

            return result;
        }

        public void Login(User user, bool rememberMe)
        {
            _signInManager.SignInAsync(user, isPersistent: rememberMe).GetAwaiter().GetResult();
        }

        public SignInResult LoginWithPassword(string email, string password, bool rememberMe)
        {
            return _signInManager.PasswordSignInAsync(email, password, rememberMe, false).GetAwaiter().GetResult();
        } 

        public void Logout()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
        }

        public bool IsLogined(ClaimsPrincipal user)
        {
            return _signInManager.IsSignedIn(user);
        }

        public void AttachRole(User user, Roles roleEnum)
        {
            //var roleName = _rolesRoute[roleEnum];
            var roleName = roleEnum.ToString();
            var role = new Role { Name = roleName };

            if (_roleManager.Roles.Contains(role) == false)
                _roleManager.CreateAsync(role).GetAwaiter().GetResult();

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

        public User GetLoginedUser()
        {
            return _userManager.GetUserAsync(_httpContext.User).GetAwaiter().GetResult();
        }

        public List<string> GetRoles(User user)
        {
            if (user == null)
                return new();

            return _userManager.GetRolesAsync(user).GetAwaiter().GetResult().ToList();
        }

        public bool ExistsRole(ClaimsPrincipal principal, params string[] roleNames)
        {
            var user = GetLoginedUser();
            var userRoles = GetRoles(user);

            foreach (var roleName in roleNames)
                if (userRoles.Contains(roleName))
                    return true;

            return false;
        }

        public bool UserIsExists(string email)
        {
            return GetUserByEmail(email) != null;
        }
    }
}
