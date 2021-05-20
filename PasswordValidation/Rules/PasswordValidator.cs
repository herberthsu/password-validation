using PasswordValidation.Rules.Password;

namespace PasswordValidation.Rules
{
    public class PasswordValidator: Validator<string>
    {
        public PasswordValidator()
        {
            Add("ContainsNoLetter", new Rule<string>(new HasAtLeastOneLetter(), "Password should contain at least 1 letter"));
            Add("ContainsNoDigit", new Rule<string>(new HasAtLeastOneDigit(), "Password should contain at least 1 digit"));
            Add("LowercaseLetterOnly", new Rule<string>(new LowercaseLettersOnly(), "Password should not contain any uppercase letter"));
            Add("LengthMinimumFiveMaximumTwelve", new Rule<string>(new LengthMinimumFiveMaximumTwelve(), "Password Length should be between 5 and 12"));
            Add("ContainsUnnecessaryCharacter", new Rule<string>(new NonSpecialCharacters(), "Password should not contain any non-digit and non-letter character"));
            Add("NotFollowBySameSequenceOfCharacters", new Rule<string>(new NotFollowBySameSequenceOfCharacters(), "Password should not contain any sequence of characters"));
        }
    }
}