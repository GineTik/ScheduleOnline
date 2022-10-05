using ScheduleOnline.BusinessLogic.Authorization;
using ScheduleOnline.Data.Repositories.IdentityImplements;

namespace ScheduleOnline.Middlewares
{
    public class AuthenticateValidationMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly UserRepository _userRespository;
        public readonly Authorizator _authorizator;

        public AuthenticateValidationMiddleware(RequestDelegate next, UserRepository userRepository, Authorizator authorizator)
        {
            _next = next;
            _userRespository = userRepository;
            _authorizator = authorizator;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var email = context.User.Identity.Name;
            var user = _userRespository.GetUserByEmail(email);

            if (user.IsRemoved == true)
                _authorizator.Logout();

            await _next(context);
        }
    }
}
