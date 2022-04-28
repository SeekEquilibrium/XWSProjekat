using User.Service.Models;

namespace User.Service.Repositories.Interface
{
   public interface IUserRepository
    {
        Task CreateAsync(AppUser entity);
        Task<IReadOnlyCollection<AppUser>> GetAllAsync();
        Task<AppUser> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(AppUser entity);
    }
}