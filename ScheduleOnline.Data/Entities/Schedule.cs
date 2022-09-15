namespace ScheduleOnline.Data.Entities
{
    public class Schedule : Entity
    {
        public string Title { get; set; }
        public string? About { get; set; }

        public bool CommentsIsAllow { get; set; }
        public int Position { get; set; }
        public int Complaints { get; set; }

        public DateTime DateOfCreation { get; set; }

        public Guid UserId { get; set; }
    }
}
