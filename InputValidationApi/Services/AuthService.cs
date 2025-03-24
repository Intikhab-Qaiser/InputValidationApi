using InputValidationApi.Interfaces;

namespace InputValidationApi.Services
{
    public class AuthService : IAuthService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashed)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashed);
        }

        public bool CanAccessAdminFeature(string role)
        {
            return role == "Admin";
        }
    }
}
