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
using User.Service.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace User.Service.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public AuthController(IMapper mapper, IUserService userService, IAuthService authService)
        {
            _mapper = mapper;
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterRequestDTO request)
        {
            if(await _userService.GetUserByUsername(request.Username) != null){
                return Conflict();
            }
            _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            AppUser user = new AppUser(
                request.Firstname,
                request.Surname,
                request.Username,
                request.IsPrivate,
                passwordHash,
                passwordSalt
            );

            await _userService.CreateUser(user);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginRequest request)
        {
            AppUser requestUser = await _userService.GetUserByUsername(request.Username);
            if(requestUser == null){
                return BadRequest("User not found.");
            }

            if (!_authService.VerifyPasswordHash(request.Password, requestUser.PasswordHash, requestUser.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = _authService.CreateToken(requestUser);

            // var refreshToken = GenerateRefreshToken();
            // SetRefreshToken(refreshToken);

            return Ok(token);
        }
    }
}