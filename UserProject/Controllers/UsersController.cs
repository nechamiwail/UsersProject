namespace UserProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using UserProject.Models;
    using UserProject.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userRepository.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
            return NoContent();
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateUser([FromBody] User user)
        {
            var validatedUser = await _userRepository.ValidateUserAsync(user.UserName, user.UserPassword);
            if (validatedUser == null)
            {
                return Unauthorized();
            }
            return Ok(validatedUser);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
