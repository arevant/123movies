using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Movies.Core.Service.Interfaces;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Movies.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserService> _logger;
        public UserService(IConfiguration configuration, ILogger<UserService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string GetToken(IdentityUser user)
        {
            try
            {
                if (user == null)
                {
                    throw new Exception("IdentityUser object can't be null");
                }

                if (string.IsNullOrWhiteSpace(user.Id))
                {
                    throw new Exception("Empty UserId");
                }

                if (string.IsNullOrWhiteSpace(user.UserName))
                {
                    throw new Exception("Empty UserName");
                }

                if (string.IsNullOrWhiteSpace(_configuration["Jwt:TokenLifetimeInMinutes"]))
                {
                    throw new Exception("TokenLifetimeInMinutes config value is null");
                }

                if (string.IsNullOrWhiteSpace(_configuration["Jwt:Key"]))
                {
                    throw new Exception("Key config value is null");
                }

                var utcNow = DateTime.UtcNow;
                var tokenLifeTimeInMinutes = Convert.ToInt32(_configuration["Jwt:TokenLifetimeInMinutes"]);

                var claims = new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString(CultureInfo.InvariantCulture))
                };

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var jwt = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Issuer"],
                    signingCredentials: signingCredentials,
                    claims: claims,
                    notBefore: utcNow,
                    expires: utcNow.AddMinutes(tokenLifeTimeInMinutes)
                    );

                return new JwtSecurityTokenHandler().WriteToken(jwt);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred in UserService - GetToken method", ex.ToString());
                throw;
            }
        }
    }
}
