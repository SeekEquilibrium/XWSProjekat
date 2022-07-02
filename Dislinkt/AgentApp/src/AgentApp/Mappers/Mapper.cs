using AutoMapper;
using AgentApp.DTO;
using AgentApp.Models;
namespace AgentApp.Mappers
{
    public class Mapper
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<User, UserDTO>();
                CreateMap<UserDTO, User>();
                CreateMap<Company, CompanyDTO>();
                CreateMap<CompanyDTO, Company>();
                CreateMap<Job, JobDTO>();
                CreateMap<JobDTO, Job>();
                CreateMap<Comment, CommentDTO>();
                CreateMap<CommentDTO, Comment>();
            }
        }
    }
}