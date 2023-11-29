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
        private readonly IUserService _userService;
        private readonly IStringHasher _stringHasher;
        public JwtAuthenticator(IConfiguration configuration, IUserService userService, IStringHasher stringHasher)
        {
            _configuration = configuration;
            _userService = userService;
            _stringHasher = stringHasher;
        }

        public async Task<TokenResponse?> Authenticate(string username, string password)
        {
            var user = await _userService.GetUserByUsernameOrEmail(username);
            if (user == null || user.Password != _stringHasher.Hash(password))
            {
                return null;
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };
            var secretKey = _configuration["jwt_key"];
            var expirationMinutes = _configuration["jwt_expiration_minutes"];
            if (secretKey != null && expirationMinutes != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["jwt_issuer"], _configuration["jwt_audience"], claims, expires: DateTime.UtcNow.AddMinutes(Double.Parse(expirationMinutes)), signingCredentials: credentials);
                var tokenHandler = new JwtSecurityTokenHandler();
                return new TokenResponse { Token = tokenHandler.WriteToken(token), Expiration = token.ValidTo };
            }
            return null;
        }
    }
}
