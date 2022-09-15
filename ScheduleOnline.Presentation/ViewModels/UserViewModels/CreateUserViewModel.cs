using System.ComponentModel.DataAnnotations;

namespace ScheduleOnline.Presentation.ViewModels.UserViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Поле ім'я є обов'язковим")]
        [MinLength(2, ErrorMessage = "Поле ім'я може складатися мінімум з 2 символи")]
        [MaxLength(255, ErrorMessage = "Поле ім'я може складатися максимум з 255 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле почти є обов'язковим")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле паролю є обов'язковим")]
        [DataType(DataType.Password)]
        [MinLength(2, ErrorMessage = "Поле паролю може складатися мінімум з 2 символи")]
        [MaxLength(255, ErrorMessage = "Поле паролю може складатися максимум з 255 символів")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Поле почти є обов'язковим")]
        public string Role { get; set; }
    }
}
