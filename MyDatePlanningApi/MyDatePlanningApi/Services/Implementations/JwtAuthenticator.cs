using Microsoft.IdentityModel.Tokens;
using MyDatePlanningApi.Models.Jwt;
using MyDatePlanningApi.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyDatePlanningApi.Services.Implementations
{
    public class JwtAuthenticator : IJwtAuthenticator
    {   private readonly IConfiguration _configuration;
        public JwtAuthenticator(IConfiguration configuration) {
            _configuration = configuration;
        }

        public TokenResponse? Authenticate(string username, string password)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };
            var secretKey = _configuration["jwt_key"];
            if (secretKey != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["jwt_issuer"], _configuration["jwt_audience"], claims, expires: DateTime.UtcNow.AddMinutes(30), signingCredentials: credentials);
                var tokenHandler = new JwtSecurityTokenHandler();
                return new TokenResponse { Token = tokenHandler.WriteToken(token), Expiration = token.ValidTo };
            }
            return null;
        }
    }
}
