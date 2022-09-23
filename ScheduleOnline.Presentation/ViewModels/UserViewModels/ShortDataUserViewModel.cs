namespace ScheduleOnline.Presentation.ViewModels.UserViewModels
{
    public class ShortDataUserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string Roles { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime DateOfRemoving { get; set; }
    }
}
