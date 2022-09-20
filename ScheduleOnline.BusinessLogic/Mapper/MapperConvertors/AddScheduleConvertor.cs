using AutoMapper;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.IdentityImplements;
using ScheduleOnline.Presentation.ViewModels.ScheduleViewModels;

namespace ScheduleOnline.BusinessLogic.Mapper.MapperConvertors
{
    public class AddScheduleConvertor : ITypeConverter<AddScheduleViewModel, Schedule>
    {
        private readonly UserRepository _userRepository;

        public AddScheduleConvertor(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Schedule Convert(AddScheduleViewModel source, Schedule destination, ResolutionContext context)
        {
            return new Schedule()
            {
                Title = source.Title,
                About = source.About,
                CommentsIsAllow = source.CommentsIsAllow,
                UserId = _userRepository.GetLoginedUser().Id
            };
        }
    }
}
