using TemperatureMonitor.Application.Database.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Application.Auth.Interfaces;
using TemperatureMonitor.Application.Auth.Models;
using TemperatureMonitor.Application.Database;

namespace TemperatureMonitor.Application.Auth
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _context;

        public AuthService(IOptions<AppSettings> appSettings, ApplicationDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public async Task<AuthenticatedUser> Login(AuthenticatingUser authenticatingUser)
        {
            AuthenticatedUser authenticatedUser = null;
            var utcNow = DateTime.UtcNow;

            var userEntity = _context.Users.FirstOrDefault(e => e.Name == authenticatingUser.Name);

            if (userEntity != null && userEntity.Password == authenticatingUser.Password)
            {
                authenticatedUser = new AuthenticatedUser
                {
                    Id = userEntity.Id.ToString(),
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    Token = GetToken(userEntity)
                };
            }

            return await Task.FromResult(authenticatedUser);
        }

        private string GetToken(UserEntity userEntity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Jwt.Issuer,
                Audience = _appSettings.Jwt.Audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, userEntity.Id.ToString()),
                    new(ClaimTypes.Name, userEntity.Name),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

                }),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.Jwt.ExpiresInMins ?? 5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Jwt.SecretKey)),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
