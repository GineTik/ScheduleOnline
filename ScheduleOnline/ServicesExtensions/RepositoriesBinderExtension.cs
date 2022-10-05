using ScheduleOnline.Data.Repositories.EFImplements;
using ScheduleOnline.Data.Repositories.IdentityImplements;
using ScheduleOnline.Data.Repositories.Interfaces;

namespace ScheduleOnline.ServicesExtensions
{
    public static class RepositoriesBinderExtension
    {
        public static void BindRepositories(this IServiceCollection services)
        {
            services.AddTransient<UserRepository>();
            services.AddTransient<RoleRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<IDayRepository, DayRepository>();
        }
    }
}
