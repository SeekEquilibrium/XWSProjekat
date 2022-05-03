using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.Service.Models;
using User.Service.DTO;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using User.Service.Service.Implements.Interfaces;
namespace User.Service.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IUserService _userService;
        public AuthController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterRequestDTO request)
        {
            AppUser userExists = await _userService.GetUserByUsername(request.Username);
            if(userExists != null){
                return Conflict();
            }
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            AppUser user = new AppUser(
                request.Firstname,
                request.Surname,
                request.Username,
                passwordHash,
                passwordSalt
            );

            await _userService.CreateUser(user);
            return Ok(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}