namespace ScheduleOnline.Data.Entities
{
    public class Comment : Entity
    {
        public string Text { get; set; }
        public DateTime DateOfCreation { get; set; }

        public int PositiveRating { get; set; }
        public int NegativeRating { get; set; }

        public bool IsFixed { get; set; }
        public int FixedPosition { get; set; }

        public bool IsRemoved { get; set; }
        public DateTime DateOfRemoving { get; set; }

        public Guid UserId { get; set; }
        public Guid ScheduleId { get; set; }
    }
}
