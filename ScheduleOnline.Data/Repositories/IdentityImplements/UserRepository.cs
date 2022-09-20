using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ScheduleOnline.Data.Entities;
using Roles = ScheduleOnline.Data.Repositories.IdentityImplements.RoleRepository.Roles;

namespace ScheduleOnline.Data.Repositories.IdentityImplements
{
    public class UserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleRepository _roleRepository;

        public HttpContext HttpContext { get; private set; }

        public UserRepository(UserManager<User> userManager, RoleRepository roleRepository, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _roleRepository = roleRepository;
            HttpContext = accessor.HttpContext;
        }

        public IdentityResult CreateUser(User user, string password, Roles role)
        {
            if (UserIsExists(user.Email) == true)
                return IdentityResult.Failed(new IdentityError() { Description = "Такий користувач вже існує" });

            var result = _userManager.CreateAsync(user, password).GetAwaiter().GetResult();

            if (result.Succeeded == true)
                _roleRepository.AttachRole(user, role);

            return result;
        }

        public List<User> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
        }

        public List<User> GetUsersByPartEmail(string partEmail)
        {
            return _userManager.Users.Where(o => o.Email.Contains(partEmail)).ToList();
        }

        public User GetUserById(Guid id)
        {
            return _userManager.FindByIdAsync(id.ToString()).GetAwaiter().GetResult();
        }

        public User GetLoginedUser()
        {
            return _userManager.GetUserAsync(HttpContext.User).GetAwaiter().GetResult();
        }

        public bool UserIsExists(string email)
        {
            return GetUserByEmail(email) != null;
        }

        public void Remove(Guid id)
        {
            var user = GetUserById(id);

            if (user == null)
                throw new ArgumentNullException("не існує користувача з таким ітендифікатором");

            if (IsRemoved(id) == true)
                throw new ArgumentException("такий користувач вже видалений");

            user.IsRemoved = true;
            user.DateOfRemoving = DateTime.UtcNow;
            _userManager.UpdateAsync(user).GetAwaiter().GetResult();
        }

        public void Restore(Guid id)
        {
            var user = GetUserById(id);

            if (user == null)
                throw new ArgumentNullException("не існує користувача з таким ітендифікатором");

            if (IsRemoved(id) == false)
                throw new ArgumentException("такий користувач не видалений, щоб відновлювати його");

            user.IsRemoved = false;
            _userManager.UpdateAsync(user).GetAwaiter().GetResult();
        }

        public bool IsRemoved(Guid id)
        {
            return GetUserById(id).IsRemoved == true;
        }
    }
}
