using ScheduleOnline.Data.EF;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.Interfaces;

namespace ScheduleOnline.Data.Repositories.EFImplements
{
    public class ScheduleRepository : EFRepository, IScheduleRepository
    {
        public ScheduleRepository(ScheduleContext context) : base(context)
        {
        }

        public void AddItem(Schedule item)
        {
            _context.Schedules.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(Schedule item)
        {
            _context.Schedules.Remove(item);
            _context.SaveChanges();
        }

        public void UpdateItem(Schedule item)
        {
            _context.Schedules.Update(item);
            _context.SaveChanges();
        }

        public IQueryable<Schedule> GetAll()
        {
            return _context.Schedules;
        }

        public Schedule? GetItem(Guid id)
        {
            return _context.Schedules.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Schedule> GetSchedulesOfUser(Guid userId)
        {
            return _context.Schedules.Where(x => x.UserId == userId);
        }
    }
}
