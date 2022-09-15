using AutoMapper;
using ScheduleOnline.BusinessLogic.Mapper.MapperConvertors;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Presentation.ViewModels.Authorization;
using ScheduleOnline.Presentation.ViewModels.UserViewModels;
using ScheduleOnline.Presentation.ViewModels.ScheduleViewModels;

namespace ScheduleOnline.BusinessLogic.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegistrationViewModel, User>()
                .ConvertUsing<RegistrationConvertor>();
            CreateMap<User, ShortDataUserViewModel>()
                .ConvertUsing<ShortDataUserConvertor>();
            CreateMap<Schedule, ShortDataScheduleViewModel>();
            CreateMap<AddScheduleViewModel, Schedule>()
                .ConvertUsing<AddScheduleConvertor>();
        }

        public override string ProfileName =>
            this.GetType().ToString();
    }
}
