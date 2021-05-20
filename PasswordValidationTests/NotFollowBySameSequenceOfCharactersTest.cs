using FluentAssertions;
using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Rules.Password;
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
        /// data: passpass
        /// expect: fail
        /// </summary>
        [Fact]
        public void TestCase1()
        {
            // arrange
            var data = "passpass";

            // act
            var actualResult = _notFollowBySameSequenceOfCharactersSpecification.IsSatisfiedBy(data);

            // assert
            actualResult.Should().BeFalse();
        }
        
        /// <summary>
        /// data: 1234512345
        /// expect: fail
        /// </summary>
        [Fact]
        public void TestCase2()
        {
            // arrange
            var data = "1234512345";

            // act
            var actualResult = _notFollowBySameSequenceOfCharactersSpecification.IsSatisfiedBy(data);

            // assert
            actualResult.Should().BeFalse();
        }
        
        /// <summary>
        /// data: pass1pass
        /// expect: pass
        /// </summary>
        [Fact]
        public void TestCase3()
        {
            // arrange
            var data = "pass1pass";

            // act
            var actualResult = _notFollowBySameSequenceOfCharactersSpecification.IsSatisfiedBy(data);

            // assert
            actualResult.Should().BeTrue();
        }
        
        /// <summary>
        /// data: 123a123123
        /// expect: fail
        /// </summary>
        [Fact]
        public void TestCase4()
        {
            // arrange
            var data = "123a123123";

            // act
            var actualResult = _notFollowBySameSequenceOfCharactersSpecification.IsSatisfiedBy(data);

            // assert
            actualResult.Should().BeFalse();
        }
        
        /// <summary>
        /// data: 20200500
        /// expect: fail
        /// </summary>
        [Fact]
        public void TestCase5()
        {
            // arrange
            var data = "20200500";

            // act
            var actualResult = _notFollowBySameSequenceOfCharactersSpecification.IsSatisfiedBy(data);

            // assert
            actualResult.Should().BeFalse();
        }
    }
}