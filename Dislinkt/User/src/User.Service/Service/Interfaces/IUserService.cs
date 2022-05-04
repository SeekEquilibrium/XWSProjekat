using User.Service.Models;

namespace User.Service.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<AppUser>> GetAll();
        Task<AppUser> GetUserById(Guid id);
        Task<AppUser> GetUserByUsername(string username);
        Task CreateUser(AppUser user);
        Task UpdateUser(AppUser user);
    }
}