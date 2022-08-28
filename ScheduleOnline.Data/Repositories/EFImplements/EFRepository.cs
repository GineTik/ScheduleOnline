using ScheduleOnline.Data.EF;

namespace ScheduleOnline.Data.Repositories.EFImplements
{
    public class EFRepository
    {
        protected ScheduleContext _context;

        public EFRepository(ScheduleContext context)
        {
            _context = context;
        }
    }
}
