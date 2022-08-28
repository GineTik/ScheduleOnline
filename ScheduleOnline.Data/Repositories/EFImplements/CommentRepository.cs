using ScheduleOnline.Data.EF;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.Interfaces;

namespace ScheduleOnline.Data.Repositories.EFImplements
{
    public class CommentRepository : EFRepository, ICommentRepository
    {
        public CommentRepository(ScheduleContext context) : base(context)
        {
        }

        public void AddItem(Comment item)
        {
            _context.Comments.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(Comment item)
        {
            _context.Comments.Remove(item);
            _context.SaveChanges();
        }

        public IQueryable<Comment> GetAll()
        {
            return _context.Comments;
        }

        public IQueryable<Comment> GetCommentsOfSchedule(Guid scheduleId)
        {
            return _context.Comments.Where(x => x.ScheduleId == scheduleId);
        }

        public Comment? GetItem(Guid id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateItem(Comment item)
        {
            _context.Comments.Update(item);
            _context.SaveChanges();
        }
    }
}
