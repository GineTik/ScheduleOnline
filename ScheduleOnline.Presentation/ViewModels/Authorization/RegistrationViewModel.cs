using System.ComponentModel.DataAnnotations;

namespace ScheduleOnline.Presentation.ViewModels.Authorization
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Обов'язкове поле")]
        [MaxLength(255, ErrorMessage = "Максимум 255 символів")]
        [MinLength(2, ErrorMessage = "Мінімум 2 символи")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Невірна почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
