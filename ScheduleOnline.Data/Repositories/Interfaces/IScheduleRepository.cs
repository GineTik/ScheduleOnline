using ScheduleOnline.Data.Entities;

namespace ScheduleOnline.Data.Repositories.Interfaces
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        IQueryable<Schedule> GetSchedulesOfUser(Guid userId);
    }
}
