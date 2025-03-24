using InputValidationApi.Models;
using InputValidationApi.Services;
using InputValidationApi.Validators;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace InputValidationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AuthService _authService = new AuthService();

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            var validator = new UserDtoValidator();
            var result = validator.Validate(userDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var hashedPassword = _authService.HashPassword(userDto.Password);

            // Simulate saving to DB
            return Ok(new
            {
                Username = userDto.Username,
                HashedPassword = hashedPassword,
                Role = userDto.Role
            });
        }

        [HttpGet("admin-feature")]
        public IActionResult AdminOnly([FromQuery] string role)
        {
            if (!_authService.CanAccessAdminFeature(role))
                return BadRequest("Only admin can access this");
                // Forbid(AuthenticationScheme.Basic, AuthenticationScheme.NTLM, "Only admin can access this");

            return Ok("Admin feature accessed!");
        }

        [HttpPost("register-data")]
        public IActionResult Register([FromBody] RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Proceed with registration
            return Ok();
        }
    }
}
