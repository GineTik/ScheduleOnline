using ScheduleOnline.Data.Entities;

namespace ScheduleOnline.Data.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IQueryable<Comment> GetCommentsOfSchedule(Guid scheduleId);
    }
}
