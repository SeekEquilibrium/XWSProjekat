using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Service.Models;
using User.Service.DTO;
using Common;

namespace User.Service.Controllers
{   
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IRepository<AppUser> _userRepository;
        public UserController(IMapper mapper, IRepository<AppUser> userRepository){
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<AppUser>>> PostAsync(UserDTO userDto){
            var user = _mapper.Map<AppUser>(userDto);
            await _userRepository.CreateAsync(user);

            return Ok(user);
        }
    

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAsync()
        {
            var users = (await _userRepository.GetAllAsync())
                        .Select(user => _mapper.Map<UserDTO>(user));

            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var responseUser = _mapper.Map<UserDTO>(user);
            return responseUser;
        }
    }
}