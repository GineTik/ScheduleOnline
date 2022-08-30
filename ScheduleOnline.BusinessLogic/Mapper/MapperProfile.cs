using AutoMapper;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Presentation.ViewModels.Authorization;
using ScheduleOnline.Presentation.ViewModels.UserViewModels;

namespace ScheduleOnline.BusinessLogic.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<LoginViewModel, User>();
            CreateMap<RegistrationViewModel, User>();
        }
    }
}
