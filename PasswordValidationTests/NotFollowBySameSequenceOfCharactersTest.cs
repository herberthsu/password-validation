using FluentAssertions;
using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Implementation;
using Xunit;

namespace PasswordValidationTests
{
    public class NotFollowBySameSequenceOfCharactersTest
    {
        private readonly ISpecification<string> _notFollowBySameSequenceOfCharactersSpecification;
        
        public NotFollowBySameSequenceOfCharactersTest()
        {
            _notFollowBySameSequenceOfCharactersSpecification = new NotFollowBySameSequenceOfCharacters();
        }
        
        /// <summary>
        /// password: passpass
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_Passpass_Should_Be_Invalid()
        {
            var actualResult = _notFollowBySameSequenceOfCharactersSpecification.IsSatisfiedBy("passpass");
            actualResult.Should().BeFalse();
        }
        
        /// <summary>
        /// password: 1234512345
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_1234512345_Should_Be_Invalid()
        {
            var actualResult = _notFollowBySameSequenceOfCharactersSpecification.IsSatisfiedBy("1234512345");
            actualResult.Should().BeFalse();
        }
        
        /// <summary>
        /// password: pass1pass
        /// expect: pass
        /// </summary>
        [Fact]
        public void Password_Pass1pass_Should_Be_Valid()
        {
            var actualResult = _notFollowBySameSequenceOfCharactersSpecification.IsSatisfiedBy("pass1pass");
            actualResult.Should().BeTrue();
        }
        
        /// <summary>
        /// password: 123a123123
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_123a123123_Should_Be_Invalid()
        {
            var actualResult = _notFollowBySameSequenceOfCharactersSpecification.IsSatisfiedBy("123a123123");
            actualResult.Should().BeFalse();
        }
        
        /// <summary>
        /// password: 20200500
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_20200500_Should_Be_Invalid()
        {
            var actualResult = _notFollowBySameSequenceOfCharactersSpecification.IsSatisfiedBy("20200500");
            actualResult.Should().BeFalse();
        }
    }
}