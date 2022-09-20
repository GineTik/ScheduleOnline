using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ScheduleOnline.Data.Entities;
using System.Security.Claims;

namespace ScheduleOnline.BusinessLogic.Services
{
    //public class UserRepository
    //{
    //    public enum Roles
    //    {
    //        User,
    //        Moderator,
    //        Admin
    //    }

    //    private readonly UserManager<User> _userManager;
    //    private readonly RoleManager<Role> _roleManager;

    //    public HttpContext HttpContext { get; private set; }

    //    public UserRepository(UserManager<User> userManager, RoleManager<Role> roleManager, IHttpContextAccessor accessor)
    //    {
    //        _userManager = userManager;
    //        _roleManager = roleManager;
    //        HttpContext = accessor.HttpContext;
    //    }

    //    public IdentityResult CreateUser(User user, string password, Roles role)
    //    {
    //        if (UserIsExists(user.Email) == true)
    //            return IdentityResult.Failed(new IdentityError(){ Description = "Такий користувач вже існує" });

    //        var result = _userManager.CreateAsync(user, password).GetAwaiter().GetResult();

    //        if (result.Succeeded == true)
    //            AttachRole(user, role);

    //        return result;
    //    }

    //    public List<User> GetAllUsers()
    //    {
    //        return _userManager.Users.ToList();
    //    }

    //    public User GetUserByEmail(string email)
    //    {
    //        return _userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
    //    }

    //    public List<User> GetUsersByPartEmail(string partEmail)
    //    {
    //        return _userManager.Users.Where(o => o.Email.Contains(partEmail)).ToList();
    //    }

    //    public User GetUserById(Guid id)
    //    {
    //        return _userManager.FindByIdAsync(id.ToString()).GetAwaiter().GetResult();
    //    }

    //    public User GetLoginedUser()
    //    {
    //        return _userManager.GetUserAsync(HttpContext.User).GetAwaiter().GetResult();
    //    }

    //    public List<string> GetRoles(User user)
    //    {
    //        if (user == null)
    //            return new();

    //        return _userManager.GetRolesAsync(user).GetAwaiter().GetResult().ToList();
    //    }

    //    public bool ExistsRole(ClaimsPrincipal principal, params string[] roleNames)
    //    {
    //        var user = GetLoginedUser();
    //        var userRoles = GetRoles(user);

    //        foreach (var roleName in roleNames)
    //            if (userRoles.Contains(roleName))
    //                return true;

    //        return false;
    //    }

    //    public bool UserIsExists(string email)
    //    {
    //        return GetUserByEmail(email) != null;
    //    }

    //    public void Remove(Guid id)
    //    {
    //        var user = GetUserById(id);

    //        if (user == null)
    //            throw new ArgumentNullException("не існує користувача з таким ітендифікатором");

    //        if (IsRemoved(id) == true)
    //            throw new ArgumentException("такий користувач вже видалений");

    //        user.IsRemoved = true;
    //        user.DateOfRemoving = DateTime.UtcNow;
    //        _userManager.UpdateAsync(user).GetAwaiter().GetResult();
    //    }

    //    public void Restore(Guid id)
    //    {
    //        var user = GetUserById(id);

    //        if (user == null)
    //            throw new ArgumentNullException("не існує користувача з таким ітендифікатором");

    //        if (IsRemoved(id) == false)
    //            throw new ArgumentException("такий користувач не видалений, щоб відновлювати його");

    //        user.IsRemoved = false;
    //        _userManager.UpdateAsync(user).GetAwaiter().GetResult();
    //    }

    //    public bool IsRemoved(Guid id)
    //    {
    //        return GetUserById(id).IsRemoved == true;
    //    }

    //    private void AttachRole(User user, Roles roleEnum)
    //    {
    //        var roleName = roleEnum.ToString();
    //        var role = new Role { Name = roleName };

    //        if (_roleManager.Roles.Contains(role) == false)
    //            _roleManager.CreateAsync(role).GetAwaiter().GetResult();

    //        _userManager.AddToRoleAsync(user, roleName).GetAwaiter().GetResult();
    //    }
    //}
}
