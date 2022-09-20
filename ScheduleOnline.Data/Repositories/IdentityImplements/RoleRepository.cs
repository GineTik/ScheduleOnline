using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ScheduleOnline.Data.Entities;

namespace ScheduleOnline.Data.Repositories.IdentityImplements
{
    public class RoleRepository
    {
        public enum Roles
        {
            User,
            Moderator,
            Admin
        }

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public HttpContext HttpContext { get; private set; }

        public RoleRepository(UserManager<User> userManager, RoleManager<Role> roleManager, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            HttpContext = accessor.HttpContext;
        }

        public List<string> GetRoles(User user)
        {
            if (user == null)
                return new();

            return _userManager.GetRolesAsync(user).GetAwaiter().GetResult().ToList();
        }

        public bool ExistsRole(User user, params string[] roleNames)
        {
            var userRoles = GetRoles(user);

            foreach (var roleName in roleNames)
                if (userRoles.Contains(roleName))
                    return true;

            return false;
        }

        public void AttachRole(User user, Roles roleEnum)
        {
            var roleName = roleEnum.ToString();
            var role = new Role { Name = roleName };

            if (_roleManager.Roles.Contains(role) == false)
                _roleManager.CreateAsync(role).GetAwaiter().GetResult();

            _userManager.AddToRoleAsync(user, roleName).GetAwaiter().GetResult();
        }
    }
}
