using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.Service.Models;
using User.Service.DTO;
using Common;
using User.Service.Clients;
using Microsoft.AspNetCore.Authorization;
using User.Service.Service.Interfaces;

namespace User.Service.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IRepository<AppUser> _userRepository;
        private readonly ConnectionClient _connectclient;
        private readonly IUserService _userService;


        public UserController(IMapper mapper, IRepository<AppUser> userRepository, ConnectionClient client,  IUserService userService){
            _mapper = mapper;
            _userRepository = userRepository;
            _connectclient = client;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<AppUser>>> PostAsync(UserDTO userDto){
            var user = _mapper.Map<AppUser>(userDto);
            await _userRepository.CreateAsync(user);
            await _connectclient.PostUserAsync(user.Id);
            return Ok(user);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult<AppUser>> PutAsync(UserEditDTO userDto){
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser currentUser = await _userService.GetUserById(new Guid(currentUserId));
            AppUser targetedUser = await _userService.GetUserByUsername(userDto.Username);
            
            // Ako targetedUser != null, postoji user sa tim username
            // Da li taj username pripada useru koji zeli da edituje
            if(targetedUser != null){
                if(targetedUser.Id != currentUser.Id){
                    return BadRequest("User with that USERNAME already exists.");
                }

            }
            var user = _mapper.Map<AppUser>(userDto);
            user.Id = currentUser.Id;
            user.PasswordHash = currentUser.PasswordHash;
            user.PasswordSalt = currentUser.PasswordSalt;
            await _userService.UpdateUser(user);
            return Ok(user);
        }
    

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAsync()
        {
            var users = (await _userService.GetAll())
                        .Select(user => _mapper.Map<UserDTO>(user));

            return Ok(users);
        }


        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAsync(string? firstname, string? surname, string? username)
        {
            if(firstname == null) firstname = string.Empty;
            if(surname == null) surname = string.Empty;
            if(username == null) username = string.Empty;

            var users = (await _userService.SearchUsers(firstname, surname, username))
                        .Select(user => _mapper.Map<UserDTO>(user));
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetByIdAsync(Guid id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }
            var responseUser = _mapper.Map<UserDTO>(user);
            return responseUser;
        }
    }
}