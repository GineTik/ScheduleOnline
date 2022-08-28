using ScheduleOnline.Data.EF;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.Interfaces;

namespace ScheduleOnline.Data.Repositories.EFImplements
{
    public class DayRepository : EFRepository, IDayRepository
    {
        public DayRepository(ScheduleContext context) : base(context)
        {
        }

        public void AddItem(Day item)
        {
            _context.Days.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(Day item)
        {
            _context.Days.Remove(item);
            _context.SaveChanges();
        }

        public IQueryable<Day> GetAll()
        {
            return _context.Days;
        }

        public IQueryable<Day> GetDaysOfSchedule(Guid scheduleId)
        {
            return _context.Days.Where(x => x.ScheduleId == scheduleId);
        }

        public Day? GetItem(Guid id)
        {
            return _context.Days.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateItem(Day item)
        {
            _context.Days.Update(item);
            _context.SaveChanges();
        }
    }
}
