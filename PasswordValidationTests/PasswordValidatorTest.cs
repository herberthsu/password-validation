using System;
using PasswordValidation.Rules;
using Xunit;
using FluentAssertions;

namespace PasswordValidationTests
{
    public class PasswordValidatorTest
    {
        [Fact]
        public void Password_Validate_Success()
        {
            // arrange
            var givenPassword = "a1b2c";
            
            // act
            var actualResult = new PasswordValidator().Validate(givenPassword);
            
            // assert
            actualResult.IsValid.Should().BeTrue();
            actualResult.Message.Should().BeNullOrEmpty();
        }
        
        [Fact]
        public void Password_Validate_Fail_ShouldAtLeastOneDigit()
        {
            // arrange
            var givenPassword = "aaaaa";
            
            // act
            var actualResult = new PasswordValidator().Validate(givenPassword);
            
            // assert
            actualResult.IsValid.Should().BeFalse();
            actualResult.Type.Should().Be("ContainsNoDigit");
            actualResult.Message.Should().Be("Password should contain at least 1 digit");
        }
        
        [Fact]
        public void Password_Validate_Fail_ShouldAtLeastOneLetter()
        {
            // arrange
            var givenPassword = "123456789012";
            
            // act
            var actualResult = new PasswordValidator().Validate(givenPassword);
            
            // assert
            actualResult.IsValid.Should().BeFalse();
            actualResult.Type.Should().Be("ContainsNoLetter");
            actualResult.Message.Should().Be("Password should contain at least 1 letter");
        }
        
        [Fact]
        public void Password_Validate_Fail_LengthMinimumFive()
        {
            // arrange
            var givenPassword = "1a2b";
            
            // act
            var actualResult = new PasswordValidator().Validate(givenPassword);
            
            // assert
            actualResult.IsValid.Should().BeFalse();
            actualResult.Type.Should().Be("LengthMinimumFiveMaximumTwelve");
            actualResult.Message.Should().Be("Password Length should be between 5 and 12");
        }
        
        [Fact]
        public void Password_Validate_Fail_LengthMaximumTwelve()
        {
            // arrange
            var givenPassword = "1a2b3c4d5e6f7g";
            
            // act
            var actualResult = new PasswordValidator().Validate(givenPassword);
            
            // assert
            actualResult.IsValid.Should().BeFalse();
            actualResult.Type.Should().Be("LengthMinimumFiveMaximumTwelve");
            actualResult.Message.Should().Be("Password Length should be between 5 and 12");
        }
        
        [Fact]
        public void Password_Validate_Fail_ShouldLowercaseLettersOnly()
        {
            // arrange
            var givenPassword = "1A2b3C4d5E6f";
            
            // act
            var actualResult = new PasswordValidator().Validate(givenPassword);
            
            // assert
            actualResult.IsValid.Should().BeFalse();
            actualResult.Type.Should().Be("LowercaseLetterOnly");
            actualResult.Message.Should().Be("Password should not contain any uppercase letter");
        }
        
        [Fact]
        public void Password_Validate_Fail_ShouldNotContainAnySpecialCharacters()
        {
            // arrange
            var givenPassword = "1a2b3c4d_5@";
            
            // act
            var actualResult = new PasswordValidator().Validate(givenPassword);
            
            // assert
            actualResult.IsValid.Should().BeFalse();
            actualResult.Type.Should().Be("ContainsUnnecessaryCharacter");
            actualResult.Message.Should().Be("Password should not contain any non-digit and non-letter character");
        }
        
        /// <summary>
        /// This case has two validation errors, but it will return the highest sequence of validation rule error
        /// 2 - ShouldAtLeastOneDigit, 3 - ShouldLowercaseLettersOnly
        /// </summary>
        [Fact]
        public void Password_Validate_Fail_ShouldAtLeastOneDigit_And_()
        {
            // arrange
            var givenPassword = "AbCdEf";
            
            // act
            var actualResult = new PasswordValidator().Validate(givenPassword);
            
            // assert
            actualResult.IsValid.Should().BeFalse();
            actualResult.Type.Should().Be("ContainsNoDigit");
            actualResult.Message.Should().Be("Password should contain at least 1 digit");
        }
    }
}