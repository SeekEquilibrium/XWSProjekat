using Common;
using Microsoft.AspNetCore.Mvc;
using User.Service.Models;
using User.Service.Service.Implements.Interfaces;

namespace User.Service.Service.Implements
{
    public class UserService : IUserService
    {
        private readonly IRepository<AppUser> _userRepository;
        public UserService(IRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AppUser> GetUserByUsername(string username)
        {
            AppUser appUser = await _userRepository.GetAsync(user => user.Username.Equals(username));
            return appUser;
        }

        public async Task CreateUser(AppUser user){
            await _userRepository.CreateAsync(user);
        }
    }
}