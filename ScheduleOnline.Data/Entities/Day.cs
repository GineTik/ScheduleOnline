namespace ScheduleOnline.Data.Entities
{
    public class Day : Entity
    {
        public string Title { get; set; }
        public int Position { get; set; }

        public DateTime DateOfCreation { get; set; }

        public Guid ScheduleId { get; set; }
    }
}
