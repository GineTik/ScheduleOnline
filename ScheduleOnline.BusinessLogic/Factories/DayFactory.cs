using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.Interfaces;

namespace ScheduleOnline.BusinessLogic.Factories
{
    public class DayFactory
    {
        public readonly IDayRepository _dayRepository;

        public DayFactory(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }

        public Day Create(Guid scheduleId)
        {
            var days = _dayRepository.GetDaysOfSchedule(scheduleId);
            var positions = days.Select(o => o.Position);
            int lastPosition = 0;

            if (positions.Count() > 0)
                lastPosition = positions.Max();

            return new Day()
            {
                Title = "Новий день",
                Position = lastPosition + 1,
                ScheduleId = scheduleId,
            };
        }
    }
}
