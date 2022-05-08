using Common;
using Microsoft.AspNetCore.Mvc;
using User.Service.Models;
using User.Service.Service.Interfaces;

namespace User.Service.Service.Implements
{
    public class UserService : IUserService
    {
        private readonly IRepository<AppUser> _userRepository;
        public UserService(IRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<AppUser>> GetAll(){
            IEnumerable<AppUser> users = await _userRepository.GetAllAsync();
            return users;
        }

        public async Task<AppUser> GetUserById(Guid id)
        {
            AppUser appUser = await _userRepository.GetAsync(user => user.Id.Equals(id));
            return appUser;
        }
        public async Task<AppUser> GetUserByUsername(string username)
        {
            AppUser appUser = await _userRepository.GetAsync(user => user.Username.Equals(username));
            return appUser;
        }

        public async Task CreateUser(AppUser user){
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateUser(AppUser user){
            await _userRepository.UpdateAsync(user);
        }
        
        public async Task<IEnumerable<AppUser>> SearchUsers(string firstname, string surname, string username){
            var users = await _userRepository.GetAllAsync(user => ((user.Firstname.ToLower().Contains(firstname.ToLower()) && firstname!=string.Empty) ||
                                                        (user.Surname.ToLower().Contains(surname.ToLower()) && surname!=string.Empty) ||
                                                        (user.Username.ToLower().Contains(username.ToLower())&& username!=string.Empty)) && !user.IsPrivate);
            return users;
        }
    }
}