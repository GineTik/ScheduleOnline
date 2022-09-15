using System.ComponentModel.DataAnnotations;

namespace ScheduleOnline.Presentation.ViewModels.ScheduleViewModels
{
    public class AddScheduleViewModel
    {
        [Required(ErrorMessage = "Поле заголовка обезательно")]
        [MinLength(2, ErrorMessage = "У полі має бути мінімум 2 символи")]
        public string Title { get; set; }

        [System.ComponentModel.DefaultValue("")]
        public string? About { get; set; }

        public bool CommentsIsAllow { get; set; }
    }
}
