using System.ComponentModel.DataAnnotations;

namespace ScheduleOnline.Presentation.ViewModels.ScheduleViewModels
{
    public class AddScheduleViewModel
    {
        [Required(ErrorMessage = "Поле заголовка обезательно")]
        [MinLength(2)]
        public string Title { get; set; }

        public string About { get; set; }

        public bool CommentsIsAllow { get; set; }
    }
}
