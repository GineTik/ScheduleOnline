using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ScheduleOnline.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Name { get; set; }
        public DateTime DateOfRegistration { get; set; }

        public bool IsRemoved { get; set; }
        public DateTime DateOfRemoving { get; set; }
    }
}
