using Microsoft.AspNetCore.Mvc;
using MyDatePlanningApi.Models.Jwt;
using MyDatePlanningApi.Services.Interfaces;

namespace MyDatePlanningApi.Controllers
{
    [Route("token")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IJwtAuthenticator _jwtAuthenticator;
        public JwtController(IJwtAuthenticator jwtAuthenticator) { 
            _jwtAuthenticator = jwtAuthenticator;
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentials credentials)
        {
            var response = _jwtAuthenticator.Authenticate(credentials.UserName, credentials.Password);
            if (response != null) 
            return Ok(response);
            return Unauthorized();
        }
    }
}
