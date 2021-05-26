using FluentAssertions;
using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Rules.Password;
using Xunit;

namespace PasswordValidationTests
{
    public class HasAtLeastOneLetterTest
    {
        private readonly ISpecification<string> _hasAtLeastOneLetterSpecification;

        public HasAtLeastOneLetterTest()
        {
            _hasAtLeastOneLetterSpecification = new HasAtLeastOneLetter();
        }
        
        /// <summary>
        /// password: 12345
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_Doesnt_Have_Any_Letter_Should_Be_Invalid()
        {
            var actualResult = _hasAtLeastOneLetterSpecification.IsSatisfiedBy("12345");
            actualResult.Should().BeFalse();
        }
        
        /// <summary>
        /// password: 123abc456
        /// expect: pass
        /// </summary>
        [Fact]
        public void Password_Does_Have_Multiple_Letters_Should_Be_Valid()
        {
            var actualResult = _hasAtLeastOneLetterSpecification.IsSatisfiedBy("123abc456");
            actualResult.Should().BeTrue();
        }
        
        /// <summary>
        /// password: 123a456
        /// expect: pass
        /// </summary>
        [Fact]
        public void Password_Does_Only_Have_One_Letter_Should_Be_Valid()
        {
            var actualResult = _hasAtLeastOneLetterSpecification.IsSatisfiedBy("abc1def");
            actualResult.Should().BeTrue();
        }
    }
}