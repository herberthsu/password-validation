using FluentAssertions;
using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Implementation;
using Xunit;

namespace PasswordValidationTests
{
    public class LengthMinimumFiveMaximumTwelveTest
    {
        private readonly ISpecification<string> _lengthMinimumFiveMaximumTwelveSpecification;
        
        public LengthMinimumFiveMaximumTwelveTest()
        {
            _lengthMinimumFiveMaximumTwelveSpecification = new LengthMinimumFiveMaximumTwelve();
        }

        /// <summary>
        /// password: word1
        /// expect: pass
        /// </summary>
        [Fact]
        public void Password_Length_Is_Exact_Five_Should_Be_Valid()
        {
            var actualResult = _lengthMinimumFiveMaximumTwelveSpecification.IsSatisfiedBy("word1");
            actualResult.Should().BeTrue();
        }
        
        /// <summary>
        /// password: password1234
        /// expect: pass
        /// </summary>
        [Fact]
        public void Password_Length_Is_Exact_Twelve_Should_Be_Valid()
        {
            var actualResult = _lengthMinimumFiveMaximumTwelveSpecification.IsSatisfiedBy("password1234");
            actualResult.Should().BeTrue();
        }
        
        /// <summary>
        /// password: a1
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_Length_Is_Less_Than_Five_Should_Be_Fail()
        {
            var actualResult = _lengthMinimumFiveMaximumTwelveSpecification.IsSatisfiedBy("a1");
            actualResult.Should().BeFalse();
        }
        
        /// <summary>
        /// password: abcdefgh12345678
        /// expect: fail
        /// </summary>
        [Fact]
        public void Password_Length_Is_More_Than_Twelve_Should_Be_Fail()
        {
            var actualResult = _lengthMinimumFiveMaximumTwelveSpecification.IsSatisfiedBy("abcdefgh12345678");
            actualResult.Should().BeFalse();
        }
    }
}