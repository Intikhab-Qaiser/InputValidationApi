namespace InputValidationApi.Interfaces
{
    public interface IAuthService
    {
        string HashPassword(string password);

        bool VerifyPassword(string password, string hashed);

        bool CanAccessAdminFeature(string role);
    }
}
