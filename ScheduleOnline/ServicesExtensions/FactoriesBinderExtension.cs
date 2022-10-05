using ScheduleOnline.BusinessLogic.Factories;

namespace ScheduleOnline.ServicesExtensions
{
    public static class FactoriesBinderExtension
    {
        public static void BindFactories(this IServiceCollection services)
        {
            services.AddTransient<DayFactory>();
        }
    }
}
