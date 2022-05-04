using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.Service.Models;
using User.Service.DTO;
using Common;
using Microsoft.AspNetCore.Authorization;
using User.Service.Service.Interfaces;

namespace User.Service.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPut]
        public async Task<ActionResult<AppUser>> PostAsync(UserDTO userDto){
            var user = _mapper.Map<AppUser>(userDto);
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