using User.Service.Models;

namespace User.Service.Service.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> GetUserByUsername(string username);
        Task CreateUser(AppUser user);
    }
}