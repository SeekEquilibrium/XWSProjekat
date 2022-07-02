using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AgentApp.Models;
using AgentApp.DTO;
using AgentApp.Services;
using AutoMapper;

namespace AgentApp.Controller
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public readonly IMapper _mapper;
        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAsync()
        {
            var users = (await _userService.GetAll())
                        .Select(user => _mapper.Map<UserDTO>(user));

            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<ActionResult<IEnumerable<User>>> Register(UserDTO userDto){
            if(await _userService.GetUserByUsername(userDto.Username) != null){
                return Conflict();
            }

            User user = new User(
                userDto.Firstname,
                userDto.Surname,
                userDto.Username,
                userDto.Password,
                userDto.Email,
                RoleEnum.USER
            );

            await _userService.CreateUser(user);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO request)
        {
            User user = await _userService.GetUserByUsername(request.Username);
            if(user == null){
                return BadRequest("User not found.");
            }

            if (request.Password.Equals(user.Password))
            {
                return BadRequest("Wrong password.");
            }

            //napraviti token

            return Ok();
        }
    }
}