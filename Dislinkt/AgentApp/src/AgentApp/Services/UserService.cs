using AgentApp.Models;
using Common;

namespace AgentApp.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAll(){
            IEnumerable<User> users = await _userRepository.GetAllAsync();
            return users;
        }

        public async Task<User> GetUserById(Guid id)
        {
            User user = await _userRepository.GetAsync(user => user.Id.Equals(id));
            return user;
        }
        public async Task<User> GetUserByUsername(string username)
        {
            User user = await _userRepository.GetAsync(user => user.Username.Equals(username));
            return user;
        }

        public async Task CreateUser(User user){
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateUser(User user){
            await _userRepository.UpdateAsync(user);
        }
    }
}