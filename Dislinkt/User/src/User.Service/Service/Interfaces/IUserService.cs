using User.Service.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace User.Service.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<AppUser>> GetAll();
        Task<AppUser> GetUserById(Guid id);
        Task<AppUser> GetUserByUsername(string username);
        Task CreateUser(AppUser user);
        Task UpdateUser(AppUser user);
        Task<IEnumerable<AppUser>> SearchUsers(string firstname, string surname, string username);

        Task<Guid> GetUserId();
    }
}