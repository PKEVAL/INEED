using INEED.API.Models;
using INEED.Common.Interfaces;
using INEED.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INEED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtTokenService _tokenService;

        public AuthController(IAuthService authService, IJwtTokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registration)
        {
            var token = await _authService.RegisterUser(registration.Username, registration.Password, registration.Email);
            return token != null ? Ok(new { token }) : BadRequest("User registration failed.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
        {
            var token = await _authService.LoginUser(login.Username, login.Password);
            return token != null ? Ok(new { token }) : Unauthorized("Login failed.");
        }
    }
}
