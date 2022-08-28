using System.ComponentModel.DataAnnotations;

namespace ScheduleOnline.Presentation.ViewModels.Authorization
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "")]
        [MaxLength(255, ErrorMessage = "")]
        [MinLength(2, ErrorMessage = "")]
        public string Name { get; set; }

        [Required(ErrorMessage = "")]
        [DataType(DataType.EmailAddress, ErrorMessage = "")]
        public string Email { get; set; }

        [Required(ErrorMessage = "")]
        [DataType(DataType.Password, ErrorMessage = "")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "")]
        public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
