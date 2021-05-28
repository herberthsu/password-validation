using PasswordValidation.Rules.Interfaces;

namespace PasswordValidation.Rules
{
    public class PasswordValidator: Validator<string>
    {
        public PasswordValidator(IHasAtLeastOneDigitRule hasAtLeastOneDigitRule, 
            IHasAtLeastOneLetterRule hasAtLeastOneLetterRule,
            ILengthMinimumFiveMaximumTwelveRule lengthMinimumFiveMaximumTwelveRule,
            ILowercaseLettersOnlyRule lowercaseLettersOnlyRule,
            INonSpecialCharactersRule nonSpecialCharactersRule,
            INotFollowBySameSequenceOfCharactersRule notFollowBySameSequenceOfCharactersRule)
        {
            Add("ContainsNoDigit", hasAtLeastOneDigitRule);
            Add("ContainsNoLetter", hasAtLeastOneLetterRule);
            Add("LowercaseLetterOnly", lowercaseLettersOnlyRule);
            Add("LengthMinimumFiveMaximumTwelve", lengthMinimumFiveMaximumTwelveRule);
            Add("ContainsUnnecessaryCharacter", nonSpecialCharactersRule);
            Add("NotFollowBySameSequenceOfCharacters", notFollowBySameSequenceOfCharactersRule);
        }
    }
}