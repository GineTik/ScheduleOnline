using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleOnline.Data.Entities
{
    public enum ActionTypes : byte
    {
        Add, 
        Remove
    }

    public enum ObjectTypes : byte
    {
        User,
        Schedule
    }

    public class HistoryItem : Entity
    {
        public Guid ObjectId { get; set; }
        [Column(TypeName = "tinyint")]
        public ObjectTypes ObjectType { get; set; }

        [Column(TypeName = "tinyint")]
        public ActionTypes ActionType { get; set; }

        public DateTime DateOfAction { get; set; }

        public Guid UserId { get; set; }
    }
}
