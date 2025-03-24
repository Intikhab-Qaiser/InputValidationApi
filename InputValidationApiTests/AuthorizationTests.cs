using InputValidationApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputValidationApiTests
{
    public class AuthorizationTests
    {
        private readonly AuthService _authService = new AuthService();

        [Fact]
        public void Admin_Should_Have_Access()
        {
            Assert.True(_authService.CanAccessAdminFeature("Admin"));
        }

        [Fact]
        public void User_Should_Not_Have_Admin_Access()
        {
            Assert.False(_authService.CanAccessAdminFeature("User"));
        }

        [Fact]
        public void Invalid_Role_Should_Not_Have_Access()
        {
            Assert.False(_authService.CanAccessAdminFeature("Guest"));
        }
    }
}
