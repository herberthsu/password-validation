using FluentAssertions;
using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Implementation;
using Xunit;

namespace PasswordValidationTests
{
    public class LowercaseLettersOnlyTest
    {
        private readonly ISpecification<string> _lowercaseLettersOnlySpecification;

        public LowercaseLettersOnlyTest()
        {
            _lowercaseLettersOnlySpecification = new LowercaseLettersOnly();
        }

        /// <summary>
        /// password: ABCDEF123
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_Has_All_Uppercase_Letters_Should_Be_Invalid()
        {
            var actualResult = _lowercaseLettersOnlySpecification.IsSatisfiedBy("ABCDEF123");
            actualResult.Should().BeFalse();
        }
        
        /// <summary>
        /// password: abcdef123
        /// expect: pass
        /// </summary>
        [Fact]
        public void Password_Has_All_Lowercase_Letters_Should_Be_Valid()
        {
            var actualResult = _lowercaseLettersOnlySpecification.IsSatisfiedBy("abcdef123");
            actualResult.Should().BeTrue();
        }
        
        /// <summary>
        /// password: abcDEF123
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_Has_Both_Uppercase_And_Lowercase_Letters_Should_Be_Invalid()
        {
            var actualResult = _lowercaseLettersOnlySpecification.IsSatisfiedBy("abcDEF123");
            actualResult.Should().BeFalse();
        }
    }
}