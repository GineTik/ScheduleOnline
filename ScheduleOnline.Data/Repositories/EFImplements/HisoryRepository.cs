using ScheduleOnline.Data.EF;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.Interfaces;

namespace ScheduleOnline.Data.Repositories.EFImplements
{
    public class HisoryRepository : EFRepository, IHistoryRepository
    {
        public HisoryRepository(ScheduleContext context) : base(context)
        {
        }

        public void AddItem(HistoryItem item)
        {
            _context.History.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(HistoryItem item)
        {
            _context.History.Remove(item);
            _context.SaveChanges();
        }

        public IQueryable<HistoryItem> GetAll()
        {
            return _context.History;
        }

        public HistoryItem? GetItem(Guid id)
        {
            return _context.History.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateItem(HistoryItem item)
        {
            _context.History.Update(item);
            _context.SaveChanges();
        }
    }
}
