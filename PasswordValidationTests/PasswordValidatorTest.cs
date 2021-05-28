using PasswordValidation.Rules;
using Xunit;
using FluentAssertions;
using PasswordValidation.Rules.Implementations;
using PasswordValidation.Specifications.Implementation;

namespace PasswordValidationTests
{
    public class PasswordValidatorTest
    {
        [Fact]
        public void Password_Validate_Success()
        {
            var actualResult = new PasswordValidator(new HasAtLeastOneDigitRule(new HasAtLeastOneDigit())).Validate("a1b2c");
            actualResult.IsValid.Should().BeTrue();
            actualResult.Message.Should().BeNullOrEmpty();
        }
        
        [Fact]
        public void Password_Validate_Fail_ShouldAtLeastOneDigit_And_ShouldLowercaseLettersOnly()
        {
            var actualResult = new PasswordValidator(new HasAtLeastOneDigitRule(new HasAtLeastOneDigit())).Validate("AbCdEf");
            actualResult.IsValid.Should().BeFalse();
            actualResult.Errors.Contains(new ValidationError(type: "ContainsNoDigit", "Password should contain at least 1 digit")).Should().BeTrue();
            actualResult.Errors.Contains(new ValidationError(type: "LowercaseLetterOnly", "Password should not contain any uppercase letter")).Should().BeTrue();
        }
    }
}