using InputValidationApi.Dtos;

namespace InputValidationApi.Interfaces
{
    public interface IUserService
    {
        UserDto GetUserById(int id);

        UserDto SaveUser(UserInputDto inputDto);
    }
}
