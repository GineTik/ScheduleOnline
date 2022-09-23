using AutoMapper;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.Data.Repositories.IdentityImplements;
using ScheduleOnline.Presentation.ViewModels.UserViewModels;

namespace ScheduleOnline.BusinessLogic.Mapper.MapperConvertors
{
    public class ShortDataUserConvertor : ITypeConverter<User, ShortDataUserViewModel>
    {
        private readonly RoleRepository _roleRepository;

        public ShortDataUserConvertor(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public ShortDataUserViewModel Convert(User source, ShortDataUserViewModel destination, ResolutionContext context)
        {
            return new ShortDataUserViewModel()
            {
                Id = source.Id,
                Name = source.Name,
                Email = source.Email,
                DateOfRegistration = source.DateOfRegistration,
                Roles = string.Join(", ", _roleRepository.GetRoles(source)),
                IsRemoved = source.IsRemoved,
                DateOfRemoving = source.DateOfRemoving,
            };
        }
    }
}
