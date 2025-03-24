using InputValidationApi.Dtos;
using InputValidationApi.Generic;
using InputValidationApi.Interfaces;
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
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UsersController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserInputDto userDto)
        {
            var validator = new UserInputDtoValidator();
            var result = validator.Validate(userDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var user = _userService.SaveUser(userDto);

            return Ok(new
            {
                user.Email,
                user.RegisteredOn
            });
        }

        //[HttpGet("admin-feature")]
        //public IActionResult AdminOnly([FromQuery] string role)
        //{
        //    if (!_authService.CanAccessAdminFeature(role))
        //        return BadRequest("Only admin can access this");
        //        // Forbid(AuthenticationScheme.Basic, AuthenticationScheme.NTLM, "Only admin can access this");

        //    return Ok("Admin feature accessed!");
        //}

        //[HttpPost("register-data")]
        //public IActionResult Register([FromBody] RegisterUserDto dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    // Proceed with registration
        //    return Ok();
        //}

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUserById(id);

            // Manual Validation
            //var validator = new UserDtoValidator();
            //var result = validator.Validate(user);

            //if (!result.IsValid)
            //    return StatusCode(500, "Output validation failed");
            //////

            // Generic response
            return Ok(new ApiResponse<Dtos.UserDto> { Data = user });

            //return Ok(user);
        }
    }
}
