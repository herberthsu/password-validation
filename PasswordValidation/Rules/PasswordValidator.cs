using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Implementation;

namespace PasswordValidation.Rules
{
    public class PasswordValidator: Validator<string>
    {
        public PasswordValidator(IHasAtLeastOneDigitRule hasAtLeastOneDigitRule, 
            IHasAtLeastOneLetterRule hasAtLeastOneLetterRule,
            ILengthMinimumFiveMaximumTwelveRule lengthMinimumFiveMaximumTwelveRule,
            ILowercaseLettersOnlyRule lowercaseLettersOnlyRule,
            INonSpecialCharactersRule nonSpecialCharactersRule)
        {
            Add("ContainsNoDigit", hasAtLeastOneDigitRule);
            Add("ContainsNoLetter", hasAtLeastOneLetterRule);
            Add("LowercaseLetterOnly", lowercaseLettersOnlyRule);
            Add("LengthMinimumFiveMaximumTwelve", lengthMinimumFiveMaximumTwelveRule);
            Add("ContainsUnnecessaryCharacter", nonSpecialCharactersRule);
            Add("NotFollowBySameSequenceOfCharacters", new Rule<string>(new NotFollowBySameSequenceOfCharacters(), "Password should not contain any sequence of characters"));
        }
        
        // public PasswordValidator()
        // {
        //     Add("ContainsNoLetter", new Rule<string>(new HasAtLeastOneLetter(), "Password should contain at least 1 letter"));
        //     Add("ContainsNoDigit", new Rule<string>(new HasAtLeastOneDigit(), "Password should contain at least 1 digit"));
        //     Add("LowercaseLetterOnly", new Rule<string>(new LowercaseLettersOnly(), "Password should not contain any uppercase letter"));
        //     Add("LengthMinimumFiveMaximumTwelve", new Rule<string>(new LengthMinimumFiveMaximumTwelve(), "Password Length should be between 5 and 12"));
        //     Add("ContainsUnnecessaryCharacter", new Rule<string>(new NonSpecialCharacters(), "Password should not contain any non-digit and non-letter character"));
        //     Add("NotFollowBySameSequenceOfCharacters", new Rule<string>(new NotFollowBySameSequenceOfCharacters(), "Password should not contain any sequence of characters"));
        // }
    }
}