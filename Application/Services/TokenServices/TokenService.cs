using CrossCutting.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.TokenServices
{
    public class TokenService : ITokenService
    {
        private const string SecretKeyProperty = "SecretKey";
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserAutenticationDto userAutenticationDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateSubject(userAutenticationDto),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = GenerateSigningCredentials()
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            userAutenticationDto.Token = tokenHandler.WriteToken(token);
            return userAutenticationDto.Token;
        }

        private SigningCredentials GenerateSigningCredentials()
        {
            var key = Encoding.ASCII.GetBytes(GetSecretKey());
            return new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
        }

        private ClaimsIdentity GenerateSubject(UserAutenticationDto userAutenticationDto)
            => new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, userAutenticationDto.Username),
                new Claim(ClaimTypes.Role, userAutenticationDto.Role)
            });

        private string GetSecretKey() => _configuration.GetValue<string>(SecretKeyProperty);
    }
}