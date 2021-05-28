using FluentAssertions;
using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Implementation;
using Xunit;

namespace PasswordValidationTests
{
    public class HasAtLeastOneDigitTest
    {
        private readonly ISpecification<string> _hasAtLeastOneDigitSpecification;

        public HasAtLeastOneDigitTest()
        {
            _hasAtLeastOneDigitSpecification = new HasAtLeastOneDigit();
        }

        /// <summary>
        /// password: abcdef
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_Doesnt_Have_Any_Digit_Should_Be_Invalid()
        {
            var actualResult = _hasAtLeastOneDigitSpecification.IsSatisfiedBy("abcdef");
            actualResult.Should().BeFalse();
        }
        
        /// <summary>
        /// password: abc123def
        /// expect: pass
        /// </summary>
        [Fact]
        public void Password_Does_Have_Multiple_Digit_Should_Be_Valid()
        {
            var actualResult = _hasAtLeastOneDigitSpecification.IsSatisfiedBy("abc123def");
            actualResult.Should().BeTrue();
        }
        
        /// <summary>
        /// password: abc1def
        /// expect: pass
        /// </summary>
        [Fact]
        public void Password_Does_Only_Have_One_Digit_Should_Be_Valid()
        {
            var actualResult = _hasAtLeastOneDigitSpecification.IsSatisfiedBy("abc1def");
            actualResult.Should().BeTrue();
        }
    }
}