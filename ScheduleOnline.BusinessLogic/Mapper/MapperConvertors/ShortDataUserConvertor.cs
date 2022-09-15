using AutoMapper;
using ScheduleOnline.BusinessLogic.Services;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Presentation.ViewModels.UserViewModels;

namespace ScheduleOnline.BusinessLogic.Mapper.MapperConvertors
{
    public class ShortDataUserConvertor : ITypeConverter<User, ShortDataUserViewModel>
    {
        private readonly UserService _userService;

        public ShortDataUserConvertor(UserService userService)
        {
            _userService = userService;
        }

        public ShortDataUserViewModel Convert(User source, ShortDataUserViewModel destination, ResolutionContext context)
        {
            return new ShortDataUserViewModel()
            {
                Name = source.Name,
                Email = source.Email,
                DateOfRegistration = source.DateOfRegistration,
                Roles = string.Join(", ", _userService.GetRoles(source))
            };
        }
    }
}
