using ScheduleOnline.Data.Entities;

namespace ScheduleOnline.Data.Repositories.Interfaces
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        IQueryable<Lesson> GetLessonsOfDay(Guid dayId);
    }
}
