using InputValidationApi.Validators;
using System.ComponentModel.DataAnnotations;

namespace InputValidationApi.Models
{
    public class RegisterUserDto
    {
        [Required]
        [MinLength(4)]
        [NoWhiteSpace(ErrorMessage = "Username cannot be empty or whitespace.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
