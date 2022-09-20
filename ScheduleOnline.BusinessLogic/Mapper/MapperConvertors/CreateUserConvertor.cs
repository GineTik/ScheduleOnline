using AutoMapper;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Presentation.ViewModels.UserViewModels;

namespace ScheduleOnline.BusinessLogic.Mapper.MapperConvertors
{
    public class CreateUserConvertor : ITypeConverter<CreateUserViewModel, User>
    {
        public User Convert(CreateUserViewModel source, User destination, ResolutionContext context)
        {
            return new User()
            {
                Email = source.Email,
                UserName = source.Email,
                Name = source.Name,
            };
        }
    }
}
