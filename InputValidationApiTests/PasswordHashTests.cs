using InputValidationApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputValidationApiTests
{
    public class PasswordHashTests
    {
        private readonly AuthService _authService = new AuthService();

        [Fact]
        public void Hash_And_Verify_Password_Should_Work()
        {
            var password = "MySecret123";
            var hashed = _authService.HashPassword(password);

            Assert.True(_authService.VerifyPassword(password, hashed));
        }

        [Fact]
        public void Verify_Should_Fail_With_Wrong_Password()
        {
            var password = "MySecret123";
            var hashed = _authService.HashPassword(password);

            Assert.False(_authService.VerifyPassword("WrongPass", hashed));
        }
    }
}
