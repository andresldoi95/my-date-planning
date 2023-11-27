using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDatePlanningApi.Models.Users;
using MyDatePlanningApi.Services.Interfaces;

namespace MyDatePlanningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(
                       IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{id}", Name = nameof(GetUserAsync))]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmailAsync([FromQuery] string email)
        {
            var user = await _userService.GetUserAsync(email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] CreateUser user)
        {
            var createdUser = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserAsync), new { id = createdUser.Id }, createdUser);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUser user)
        {
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }
    }
}
