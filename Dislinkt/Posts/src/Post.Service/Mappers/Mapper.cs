using AutoMapper;
using Post.Service.DTO;
using Post.Service.Models;

namespace Post.Service.Mappers
{
    public class Mapper
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<UserPost, CreatePostDTO>();
                CreateMap<CreatePostDTO, UserPost>();
            }
        }
    }
}