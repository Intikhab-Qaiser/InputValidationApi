using InputValidationApi.Models;
using InputValidationApi.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputValidationApiTests
{
    public class ValidationTests
    {
        [Fact]
        public void Should_Fail_When_Username_Is_Short()
        {
            var dto = new InputValidationApi.Dtos.UserInputDto { UserName = "abc", Role = "User", Email="job@atomcamp.com" };
            var validator = new UserInputDtoValidator();
            var result = validator.Validate(dto);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Should_Pass_With_Valid_Data()
        {
            var dto = new InputValidationApi.Dtos.UserInputDto { UserName = "validUser", Password = "securePass", Role = "Admin" };
            var validator = new UserInputDtoValidator();
            var result = validator.Validate(dto);
            Assert.True(result.IsValid);
        }
    }
}
