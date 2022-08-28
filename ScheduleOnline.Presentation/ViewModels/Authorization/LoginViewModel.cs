using System.ComponentModel.DataAnnotations;

namespace ScheduleOnline.Presentation.ViewModels.Authorization
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "")]
        [DataType(DataType.EmailAddress, ErrorMessage = "")]
        public string Email { get; set; }

        [Required(ErrorMessage = "")]
        [DataType(DataType.Password, ErrorMessage = "")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
