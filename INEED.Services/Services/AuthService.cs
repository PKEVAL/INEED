using INEED.Common.Interfaces;
using INEED.Data.Models;
using INEED.Data.Repositories;
using INEED.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INEED.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _tokenService;

        public AuthService(IUserRepository userRepository, IJwtTokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<string> RegisterUser(string username, string password, string email)
        {
            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Email = email
            };
            await _userRepository.AddUser(user);
            return _tokenService.GenerateToken(user);
        }

        public async Task<string> LoginUser(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return _tokenService.GenerateToken(user);
            }
            return null;
        }
    }
}
