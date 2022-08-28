namespace ScheduleOnline.Data.Entities
{
    public class Lesson : Entity
    {
        public string Title { get; set; }
        public int Position { get; set; }

        public DateTime DateOfCreation { get; set; }

        public Guid DayId { get; set; }
    }
}
