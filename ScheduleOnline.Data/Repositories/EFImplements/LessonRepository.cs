using ScheduleOnline.Data.EF;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.Interfaces;

namespace ScheduleOnline.Data.Repositories.EFImplements
{
    public class LessonRepository : EFRepository, ILessonRepository
    {
        public LessonRepository(ScheduleContext context) : base(context)
        {
        }

        public void AddItem(Lesson item)
        {
            _context.Lessons.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(Lesson item)
        {
            _context.Lessons.Remove(item);
            _context.SaveChanges();
        }

        public IQueryable<Lesson> GetAll()
        {
            return _context.Lessons;
        }

        public Lesson? GetItem(Guid id)
        {
            return _context.Lessons.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Lesson> GetLessonsOfDay(Guid dayId)
        {
            return _context.Lessons.Where(x => x.DayId == dayId);
        }

        public void UpdateItem(Lesson item)
        {
            _context.Lessons.Update(item);
            _context.SaveChanges();
        }
    }
}
