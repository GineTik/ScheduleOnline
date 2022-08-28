using ScheduleOnline.Data.Entities;

namespace ScheduleOnline.Data.Repositories.Interfaces
{
    public interface IDayRepository : IRepository<Day>
    {
        IQueryable<Day> GetDaysOfSchedule(Guid scheduleId);
    }
}
