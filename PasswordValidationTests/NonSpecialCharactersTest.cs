using FluentAssertions;
using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Rules.Password;
using Xunit;

namespace PasswordValidationTests
{
    public class NonSpecialCharactersTest
    {
        private readonly ISpecification<string> _nonSpecialCharactersSpecification;

        public NonSpecialCharactersTest()
        {
            _nonSpecialCharactersSpecification = new NonSpecialCharacters();
        }

        /// <summary>
        /// password: aA01
        /// expect: pass
        /// </summary>
        [Fact]
        public void Password_Has_No_Special_Character_Should_Be_Valid()
        {
            var actualResult = _nonSpecialCharactersSpecification.IsSatisfiedBy("aA01");
            actualResult.Should().BeTrue();
        }
        
        /// <summary>
        /// password: Aa@123
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_Has_One_Special_Character_Should_Be_Invalid()
        {
            var actualResult = _nonSpecialCharactersSpecification.IsSatisfiedBy("Aa@123");
            actualResult.Should().BeFalse();
        }

        /// <summary>
        /// password: Aa@$_&123
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_Has_Multiple_Special_Characters_Should_Be_Invalid()
        {
            var actualResult = _nonSpecialCharactersSpecification.IsSatisfiedBy("Aa@$_&123");
            actualResult.Should().BeFalse();
        }
    }
}