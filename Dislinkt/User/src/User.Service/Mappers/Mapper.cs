using AutoMapper;
using User.Service.DTO;
using User.Service.Models;
namespace User.Service.Mappers
{
    public class Mapper
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<AppUser, UserDTO>();
                CreateMap<UserDTO, AppUser>();

                CreateMap<AppUser, UserEditDTO>();
                CreateMap<UserEditDTO, AppUser>();
            }
        }
    }
}