using InputValidationApi.Dtos;
using InputValidationApi.Entities;
using InputValidationApi.Interfaces;
using InputValidationApi.Models;

namespace InputValidationApi.Services
{
    public class UserService : IUserService
    {
        private IAuthService _authService;
        public UserService(IAuthService authService)
        {
            _authService = authService;
        }

        public Dtos.UserDto GetUserById(int id)
        {
            // TODO: Get from DB
            var userEntity = new UserEntity
            {
                Id = id,
                Email = "jon@atomcamp.com",
                Role = "Admin",
                UserName = "Jon Doe",
                PasswordHash = _authService.HashPassword("password"),
                CreatedAt = DateTime.Now,
            };

            return new Dtos.UserDto
            {
                Email = "jon@atomcamp.com",
                RegisteredOn = userEntity.CreatedAt.ToString("yyyy-MM-dd"),
                Role = userEntity.Role,
                UserName = userEntity.UserName
            };
        }

        public Dtos.UserDto SaveUser(UserInputDto userDto)
        {
            var hashedPassword = _authService.HashPassword(userDto.Password);

            var userEntity = new UserEntity 
            {
                Id = 1,
                Email = userDto.Email,
                PasswordHash = hashedPassword,
                CreatedAt = DateTime.Now,
            };

            // TODO: Save user to DB

            return new Dtos.UserDto
            {
                Email = userDto.Email,
                RegisteredOn = userEntity.CreatedAt.ToString("yyyy-MM-dd")
            };

        }

    }
}
