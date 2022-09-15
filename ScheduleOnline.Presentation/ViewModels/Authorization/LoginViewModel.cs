using System.ComponentModel.DataAnnotations;

namespace ScheduleOnline.Presentation.ViewModels.Authorization
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Обов'язкове поле")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Невірна почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
