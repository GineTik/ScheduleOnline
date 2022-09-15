using AutoMapper;
using ScheduleOnline.BusinessLogic.Services;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Presentation.ViewModels.ScheduleViewModels;

namespace ScheduleOnline.BusinessLogic.Mapper.MapperConvertors
{
    public class AddScheduleConvertor : ITypeConverter<AddScheduleViewModel, Schedule>
    {
        private readonly UserService _userService;

        public AddScheduleConvertor(UserService userService)
        {
            _userService = userService;
        }

        public Schedule Convert(AddScheduleViewModel source, Schedule destination, ResolutionContext context)
        {
            return new Schedule()
            {
                Title = source.Title,
                About = source.About,
                CommentsIsAllow = source.CommentsIsAllow,
                UserId = _userService.GetLoginedUser().Id
            };
        }
    }
}
