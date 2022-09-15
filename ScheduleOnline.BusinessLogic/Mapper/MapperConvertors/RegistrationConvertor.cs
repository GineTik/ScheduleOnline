using AutoMapper;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Presentation.ViewModels.Authorization;

namespace ScheduleOnline.BusinessLogic.Mapper.MapperConvertors
{
    public class RegistrationConvertor : ITypeConverter<RegistrationViewModel, User>
    {
        public User Convert(RegistrationViewModel source, User destination, ResolutionContext context)
        {
            return new User()
            {
                Name = source.Name,
                UserName = source.Email,
                Email = source.Email,
            };
        }
    }
}
